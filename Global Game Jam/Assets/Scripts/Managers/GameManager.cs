using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // GameManger Instance
    public static GameManager Instance;

    // Current Game State
    public bool gameState = true;
    public bool respawn;

    public float timerEmpty;
    public float initTimer;
    public float timeRemaining;

    public AudioManager audioManager { get; private set; }

    public Image uiOuter;

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
        var tempColor = uiOuter.color;
        tempColor.a = (initTimer - timeRemaining) / initTimer;
        uiOuter.color = tempColor;
        if (timeRemaining < 10)
            GameObject.Find("Player Model").GetComponent<PlayerMovement>().DamagePlayer(3);
    }


    public void Timer()
    {

        if (timeRemaining > 0f && gameState == true)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            respawn = true;
            timeRemaining = initTimer;
            StartCoroutine(RespawnBool());
            audioManager.music[3].volume -= 0.0005f;
            audioManager.music[0].volume += 0.0005f;
        }

    }

    IEnumerator RespawnBool()
    {
        yield return new WaitForSeconds(1f);
        respawn = false;
    }
}
