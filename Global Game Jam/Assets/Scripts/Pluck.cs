using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pluck : MonoBehaviour
{
    public Rigidbody2D chainStart;
    public float pluckStrength = -100f;

    private void Start() 
    {
    }

    private void Update() 
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            chainStart.bodyType = RigidbodyType2D.Dynamic;
            chainStart.AddForce(transform.up * pluckStrength);
            Destroy(this.GetComponent<PlayerMovement>());
        }




    }


}
