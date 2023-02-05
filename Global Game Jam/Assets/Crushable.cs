using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crushable : MonoBehaviour
{
    int noOfTouching = 0;

    [SerializeField]
    int noToCrush = 5;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        noOfTouching += 1;
        Debug.Log(noOfTouching);
        if (noOfTouching >= 5)
        {
            Debug.Log("CRUSHED");
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        noOfTouching -= 1;
    }
}
