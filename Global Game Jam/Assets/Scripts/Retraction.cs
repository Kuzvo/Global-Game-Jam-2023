using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retraction : MonoBehaviour
{
    /*
     * Retraction functionality:
     *  Player movement locked
     *  Player pulled through nearest door behind them (e.g., below)
     *  Simultaneously fades to black
     *  Player is placed back in set hub location
     */

    public bool canMove;
    public GameObject hubLocation;
    public GameObject player;
    public float timer;

    void Start() 
    {
        canMove = true;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
            {
            //add force here on chain
            //coroutine

            player.transform.position = hubLocation.transform.position;

        }
    }


    IEnumerator TendrilAnimation() 
    {


       yield return new WaitForSeconds(2.5f);


    }
}
