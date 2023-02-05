using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SteeringAgent : MonoBehaviour
{

// pay dylan
public float creeperExplosionDistance;
public float enemyFOV;
[SerializeField] bool seenPlayer;
public float stalkerDamageDistance;


[SerializeField] Animator anim;

	protected const float DefaultUpdateTimeInSecondsForAI = 0.1f;

	/// <summary>
	/// Adjusts the frequency time in seconds of when the AI will  updates its logic
	/// </summary>
	[SerializeField]
	[Range(0.005f, 5.0f)]
	protected float maxUpdateTimeInSecondsForAI = DefaultUpdateTimeInSecondsForAI;

	/// <summary>
	/// Returns the maximum speed the agent can have
	/// NOTE: [field: SerializeField] exposes a C# property to Unity's inspector which is useful to toggle at runtime
	/// </summary>
	[field: SerializeField]
	public float MaxCurrentSpeed { get; protected set; } = 400.0f;

	/// <summary>
	/// Returns the maximum steering speed that will be applied to the steering velocity
	/// NOTE: [field: SerializeField] exposes a C# property to Unity's inspector which is useful to toggle at runtime
	/// </summary>
	[field: SerializeField]
	public float MaxSteeringSpeed { get; protected set; } = 100.0f;

	/// <summary>
	/// Returns the current velocity of the Agent
	/// </summary>
	public Vector3 CurrentVelocity	{ get; protected set; }

	/// <summary>
	/// Returns the steering velocity of the Agent
	/// </summary>
	public Vector3 SteeringVelocity { get; protected set; }

	/// <summary>
	/// Stores a list of all steering behaviours that are on a SteeringAgent GameObject, regardless if they are enabled or not
	/// </summary>
	private List<SteeringBehaviour> steeringBehvaiours = new List<SteeringBehaviour>();

	/// <summary>
	/// Tracks how many seconds have elapsed since last CooperativeArbitration function has run
	/// </summary>
	private float updateTimeInSecondsForAI;

 public GameObject player;

public bool hasAttacked;
float distance;
float audioCounter;

bool facingright;

        float preXPos;


		void Awake()
		{
			player = GameObject.FindGameObjectWithTag("Player");
		}

public GameObject stalkerPrefab;

	/// <summary>
	/// Called once per frame
	/// </summary>
	private void Update()
	{
		updateTimeInSecondsForAI += Time.deltaTime;
		while (updateTimeInSecondsForAI >= maxUpdateTimeInSecondsForAI)
		{
			updateTimeInSecondsForAI -= maxUpdateTimeInSecondsForAI;
			CooperativeArbitration();
		}

if (seenPlayer)
{
		UpdatePosition();

}

if (distance < enemyFOV)
{
	seenPlayer = true;
	GameManager.Instance.audioManager.transDangerMusic = true;
}	
else if(distance > enemyFOV)
{
	seenPlayer = false;
	if (GameManager.Instance.audioManager.music[3].volume == 1)
	{
	GameManager.Instance.audioManager.transDangerMusic = false;
	}
}

if (hasAttacked)
{ 
   // audioCounter = 0;
StartCoroutine(StalkerReagress());
}

distance = (player.gameObject.transform.position - transform.position).magnitude;


float flipDis= (player.gameObject.transform.position.x - transform.position.x);


StalkerDistanceCheck();

if (!hasAttacked)
{
if (flipDis > 0 && !facingright)
{
	transform.Rotate(0,180,0);
	facingright = true;
}
else if (flipDis < 0 && facingright)
{
transform.Rotate(0,180f,0);
facingright = false;
}
}
CreeperCheck();
 
	}


IEnumerator StalkerReagress()
{

       yield return new WaitForSeconds (1.5f);

       hasAttacked = false;
       if (audioCounter == 0)
       {

			   	transform.Rotate(0,180,0);
		
        audioCounter += 1;
        GameManager.Instance.audioManager.PlayStalkerReagress();
        }
       
}

void StalkerDistanceCheck()
{
    if (gameObject.tag == "Stalker")
    { 
      if (hasAttacked == false && distance < stalkerDamageDistance)
        {
              hasAttacked = true;
             
              StartCoroutine(DumbCol());  
        }
    }  
}


IEnumerator DumbCol()
{
yield return new WaitForSeconds (0.3f); 
		
       Vector3 prevPoint = new Vector3(transform.position.x,transform.position.y, transform.position.z );
            stalkerPrefab = (GameObject)Instantiate(stalkerPrefab, prevPoint, Quaternion.identity);
  	transform.Rotate(0,180,0);
	    player.GetComponent<PlayerMovement>().DamagePlayer(1); 
              GameManager.Instance.audioManager.PlayStalkerAttack();
Destroy(gameObject); 
           
            
}

void CreeperCheck()
{
    if (gameObject.tag == "Creeper")
{

if (distance < creeperExplosionDistance/ 2)
{
    CurrentVelocity = new Vector3(0f, 0f, 0f);
    StartCoroutine(CreeperExplode());
}
}
}

       IEnumerator CreeperExplode()
    {
      yield return new WaitForSeconds (1.5f);
		anim.Play("CreeperExplodeAnim");
    }

void CreeperWindUpNoise()
{
    GameManager.Instance.audioManager.PlayCreeperExplosion();
}

void CreeperEffectAnim()
{
	    if (distance < creeperExplosionDistance)
    {
        player.GetComponent<PlayerMovement>().DamagePlayer(1);
    }
	     Destroy(gameObject);
}

	protected virtual void CooperativeArbitration()
	{
		SteeringVelocity = Vector3.zero;
		
		GetComponents<SteeringBehaviour>(steeringBehvaiours);
		foreach (SteeringBehaviour currentBehaviour in steeringBehvaiours)
		{
			if(currentBehaviour.enabled)
			{
				SteeringVelocity += currentBehaviour.UpdateBehaviour(this);
			}
		}
	}

	/// <summary>
	/// Updates the position of the GAmeObject via Teleportation. In Craig Reynolds architecture this would the Locomotion layer
	/// </summary>
	protected virtual void UpdatePosition()
	{
		// Limit steering velocity to supplied maximum so it can be used to adjust current velocity. Ensure to subtract this limnited
		// amount from the current value of the steering velocity so that it decreases as over multiple game frames to reach the target
		var limitedSteeringVelocity = Helper.LimitVector(SteeringVelocity, MaxSteeringSpeed * Time.deltaTime);
		SteeringVelocity -= limitedSteeringVelocity;

		// Set final velocity
		CurrentVelocity += limitedSteeringVelocity;
		CurrentVelocity = Helper.LimitVector(CurrentVelocity, MaxCurrentSpeed);

		transform.position += CurrentVelocity * Time.deltaTime;

	}
}
