using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 targetPos;
    Vector3 direction;

    [Range(0.1f, 25.0f)]
    public float bulletSpeed = 1.0f;

    bool active = false;
    Vector3 startPos;


    GameObject Player;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        GameManager.Instance.audioManager.PlayTurretShoot();
        startPos = transform.position;
    }
    private void Update()
    {
        if (active)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, bulletSpeed * Time.deltaTime);

            transform.up = targetPos - transform.position;
        }
            
    }

    public void SetTarget(Vector3 dir)
    {
        targetPos = dir;
        transform.up = targetPos - direction;
        Debug.Log("Direction: " + direction + " TargetPos: " + targetPos);
        active = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO: Bullet Hits
if (collision.gameObject.tag == "Player")
{
    if (Player != null)
    Player.GetComponent<PlayerMovement>().DamagePlayer(1);
}
        Debug.Log("Bullet hit Object: " + collision.name);
        Destroy(gameObject);
    }
}
