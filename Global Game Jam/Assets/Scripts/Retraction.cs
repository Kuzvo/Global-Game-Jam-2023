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
    public float timerEmpty;
    public float initTimer;
    public float timeRemaining;

    public bool gameState = true;

    [SerializeField]
    public GameManager gameManager;

    void Start() 
    {
        canMove = true;
        timeRemaining = initTimer;
       
    }

    void Update()
    {
        if (timeRemaining > 0f && gameState == true) 
        {
            timeRemaining -= Time.deltaTime;
        }
        else 
        {
            timeRemaining = initTimer;
        }
        
        if(timeRemaining <= timerEmpty)
            {
            StartCoroutine(TendrilAnimation());

        }
    }

    IEnumerator TendrilAnimation() 
    {
       Debug.Log("QUEUE ANIMATION");
       yield return new WaitForSeconds(2.5f);
       
       player.transform.position = hubLocation.transform.position;
    }
}
