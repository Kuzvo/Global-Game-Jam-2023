using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float playerHealth = 3;

bool hasIFrames;

 [SerializeField] float playerSpd;
 float moveX;
 float moveY;

    public Image heart1;
    public Image heart2;
    public Image heart3;


    [SerializeField] Camera cam;

Vector3 camVec;

    public Sprite idle;
    public Sprite right;
    public Sprite left;
    public Sprite flicker;
    public Sprite dead;

    [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = idle;  
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (rb.velocity.magnitude < 0.1f) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = idle;

        } else if (rb.velocity.magnitude > 0.1f && (Input.GetKeyDown(KeyCode.A)) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = left;

        } else if (rb.velocity.magnitude > 0.1f && Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = right;
        }

        rb.velocity = new Vector2( playerSpd * moveX, playerSpd * moveY);

       camVec = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);

       cam.transform.position = camVec;

       
    }

public void DamagePlayer(int damage)
{
    if (hasIFrames)
    return;
    else 
    {
    hasIFrames = true;
    playerHealth -= damage;
            StartCoroutine(DamageFlicker());
            StartCoroutine(HeartReduce());
    StartCoroutine(RemoveIFrames());
    if (playerHealth == 0)
    {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = dead;
                GetComponent<Pluck>().Plucknfuck();
    }
    }

}
IEnumerator RemoveIFrames()
{
yield return new WaitForSeconds (1f);
hasIFrames = false;
}

IEnumerator DamageFlicker() {

        this.gameObject.GetComponent<SpriteRenderer>().sprite = flicker;
        yield return new WaitForSeconds(0.1f);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = idle;

    }

    IEnumerator HeartReduce() {
/*
        if(heart3.enabled) {
            
            heart3.enabled = !heart3.enabled;
        }
        else if (!heart3.enabled && heart2.enabled) {
            heart2.enabled = !heart2.enabled;
        }
        else if (!heart3.enabled && !heart2.enabled) {
            heart1.enabled = !heart1.enabled;
        }
 */
        yield return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.tag == "Spikes")
            GetComponent<PlayerMovement>().DamagePlayer(1);
    }

}
