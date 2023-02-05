using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject playerPrefab;
    public GameObject pluck;
   

    public bool gameState = true;

    [SerializeField]
    public GameManager gameManager;

    void Start() 
    {
        canMove = true;
        
       
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
        pluck.GetComponent<Pluck>().Plucknfuck();
        yield return new WaitForSeconds(2.0f);
        Destroy(player);
        
    }
}
