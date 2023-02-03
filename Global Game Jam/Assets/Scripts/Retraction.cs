using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    /*
     * Retraction functionality:
     *  Player movement locked
     *  Player pulled through nearest door behind them (e.g., below)
     *  Simultaneously fades to black
     *  Player is placed back in set hub location
     */

    public bool canMove;
    public float hubLocation;
    public GameObject player;
    public float timer;

    void Start() 
    {
        canMove = true;
    }

    void Update()
    {
        if(timer == 0) {

        }
    }
}
