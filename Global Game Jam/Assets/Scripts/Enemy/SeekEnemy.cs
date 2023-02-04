using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekEnemy : MonoBehaviour
{

      [SerializeField] GameObject player;
      [SerializeField] Rigidbody2D rb;

      [SerializeField] float agentSpd;

      Vector3 desiredVelocity;
      Vector3 steeringVelocity;

      Vector3 velocity, location;
      float maxSpeed;
     

    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
        location = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Seek();
    }


void Seek()
{
desiredVelocity = Vector3.Normalize(player.transform.position - transform.position) * agentSpd;

Vector3 currentVelocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);

steeringVelocity = desiredVelocity - currentVelocity;


 velocity = Vector3.ClampMagnitude(velocity + steeringVelocity, maxSpeed);

 location += velocity * Time.deltaTime;

 //steeringVelocity = Vector3.zero;

 transform.position += location;
}

}
