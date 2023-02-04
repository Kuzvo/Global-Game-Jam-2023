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
            Destroy(this.GetComponent<PlayerMovement>());
            StartCoroutine(PluckAway());
        }
    }

    IEnumerator PluckAway()
    {
        for (int i = 0; i < 10; i++)
        {
            chainStart.AddForce(transform.up * pluckStrength);
            yield return new WaitForSeconds(0.1f);
        }
    }


}
