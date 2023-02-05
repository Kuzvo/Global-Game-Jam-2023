using System.Collections;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{    // Instantiate Variables
    // targetDir is the direction between the turret and the player
    Vector3 targetDir;
    // Player Reference
    GameObject player;
    // Speed of the rotation
    public float speed;
    // Max following angle - blindspot (between -1 and 1)
    public float maxFollowAngle;
    // Max distance - sight line
    public float maxDistanceFromPlayer;

    // Time inbetween fire;
    public float timeBetweenFire = 1f;

    float nextFireTime;

    bool isActive = false;

    public GameObject bulletPrefab;

    public Animator animator;
    RaycastHit hit;

    // Waits two seconds after being closely locked on before firing
    public float timeToFire = 2f;
    public void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(CheckDistance());
    }
    private void Update()
    {
        // If IsVisible returns true
        if (isActive)
        {
            // Finds the direction to the target
            targetDir = player.transform.position - transform.position;
            // Finds the amount of rotation the turret has to turn to face the player
            var newDirection = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            // Takes the rotation and actually does it
            // TODO: IF TIME does this work?
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(newDirection, Vector3.forward), Time.deltaTime * speed);
        }
    }

    // Checks if the player is visible (both if not in blindspot and sight distance)
    private bool IsVisible()
    {
        var dot = Vector2.Dot(transform.right, (player.transform.position - transform.position).normalized);
        
        if (dot > maxFollowAngle)
        {
            // If the player is within the maxDistance (distance between turret and player)
            if (Vector2.Distance(transform.position, player.transform.position) < maxDistanceFromPlayer)
            {
                animator.SetBool("lockedOn", true);
                if (nextFireTime == 0)
                {
                    // TODO: Locked on Anim
                    nextFireTime = Time.time + (timeBetweenFire / 2);
                }
                else if (Time.time >= nextFireTime)
                {
                    Fire(player.transform.position);
                }
                // Returns true (the player is visible)
                return true;
            }
        }
        // Resets the FireTime timer
        nextFireTime = 0f;
        animator.SetBool("lockedOn", false);
        // TODO: Base Anim

        // Returns false (the player is not visible)
        return false;
    }

    private void Fire(Vector3 targetPos)
    {
        Debug.Log("Fire");
        // TODO: Play Audio
        nextFireTime = Time.time + timeBetweenFire;
        // TODO: Kill player
        // Get Direction
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, null);
        bullet.GetComponent<Bullet>().SetTarget(targetPos);
    }

    public IEnumerator CheckDistance()
    {
        for (int i = 0; i < i + 1;)
        {
            // TODO: If visible
            if (IsVisible())
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
