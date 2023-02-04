using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

 [SerializeField] float playerSpd;
 float moveX;
 float moveY;

 bool facingRight;

[SerializeField] Camera cam;

Vector3 camVec;


 [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
      facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

        if (Input.GetKeyDown(KeyCode.U)) {
            cam = null;
        }
    }

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

           if (facingRight == true && moveX < 0)
           {
              transform.Rotate(0f, 180f, 0f);
              facingRight = false;
           }
           if (facingRight == false && moveX > 0)
           {
              transform.Rotate(0f, -180f, 0f);
              facingRight = true;
           }


       rb.velocity = new Vector2( playerSpd * moveX, playerSpd * moveY);

       camVec = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);

       cam.transform.position = camVec;

       
    }
}
