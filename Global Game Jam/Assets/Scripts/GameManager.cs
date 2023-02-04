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

    [Range(10.0f, 1080.0f)]
    public float timerForLevel = 120;
    private float timeLeft;

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
    }


    private void Update()
    {
        // If game state is stopped, do not count
        if (gameState != false)
            timeLeft -= Time.deltaTime;
        // If timer has not concluded
        if (timeLeft > 0)
            UpdateTimer();
        // Timer has concluded
        else
            Restart();
    }

    private void UpdateTimer()
    {
        int timeInMinutes = (int)(timeLeft / 60.0f);
        int timeInSeconds = (int)(timeLeft) - (timeInMinutes * 60);

        // Deal with text
        if (timeInSeconds < 10);
        // Update Text with time in minutes.
        else;
        // Update Text with time in seconds.
    }

    public void PauseGame()
    {
        Debug.Log("Pause Game");
        gameState = !gameState;

        if (gameState)
        {
            // Enable Controls
            // Hide UI
        }
        else
        {
            // Disable Controls
            // Show UI
            // Change Cursor State
        }
    }

    // Restart
    public void Restart()
    {
        SceneManager.LoadScene("Main Scene");
    }
}
