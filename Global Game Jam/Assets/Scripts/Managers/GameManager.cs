using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // GameManger Instance
    public static GameManager Instance;

    // Current Game State
    public bool gameState = true;


    public float timerEmpty;
    public float initTimer;
    public float timeRemaining;

    public AudioManager audioManager { get; private set; }

    private void Awake()
    {
        // Delete other instances
        if (Instance == null)
        {
            Instance = this;
        }
        if (Instance != this)
        {
            Destroy(gameObject);
        }

            audioManager = GetComponent<AudioManager>();

        timeRemaining = initTimer;

    }


    private void Update()
    {
        Timer();
    
    
    }


    public void Timer() {

        if (timeRemaining > 0f && gameState == true) {
            timeRemaining -= Time.deltaTime;
        } else {
            timeRemaining = initTimer;
        }

    }

}
