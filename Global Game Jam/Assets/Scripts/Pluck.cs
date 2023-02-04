using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pluck : MonoBehaviour
{
    public Rigidbody2D chainStart;
    public float pluckStrength = -100f;

    private void Start() 
    {
        chainStart = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            chainStart.AddForce(transform.up * pluckStrength);
        }




    }


}
