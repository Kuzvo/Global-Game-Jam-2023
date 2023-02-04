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

    public Sprite idle;
    public Sprite right;
    public Sprite left;



    [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
      facingRight = true;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = idle;

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

        if (rb.velocity.magnitude < 0.1f) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = idle;

        } else if (rb.velocity.magnitude > 0.1f && Input.GetKeyDown(KeyCode.A)) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = left;

        } else if (rb.velocity.magnitude > 0.1f && Input.GetKeyDown(KeyCode.D)) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = right;
        }






        rb.velocity = new Vector2( playerSpd * moveX, playerSpd * moveY);

       camVec = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);

       cam.transform.position = camVec;

       
    }
}
