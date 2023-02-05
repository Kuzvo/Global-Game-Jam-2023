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
   

    public bool gameState = true;

    [SerializeField]
    public GameManager gameManager;

    void Start() 
    {
        canMove = true;
         player = GameObject.FindGameObjectWithTag("Player");
       
    }

    void Update()
    {

        gameManager.Timer();
        
        if(gameManager.timeRemaining <= gameManager.timerEmpty)
            {
            StartCoroutine(TendrilAnimation());

        }
    }

    IEnumerator TendrilAnimation() 
    {
        yield return null;
       
       player.transform.position = hubLocation.transform.position;
    }
}
