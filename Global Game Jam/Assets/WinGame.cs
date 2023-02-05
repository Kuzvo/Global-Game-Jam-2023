using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public ShapePuzzle[] shapePuzzles;

    bool win = true;

    private void Update()
    {
        win = true;
        for (int i = 0; i < shapePuzzles.Length; i++)
        {
            if (shapePuzzles[i].complete == true)
            {
                win = false;
            }
        }
        if (win == true)
        {
            SceneManager.LoadScene("WIN SCENE");
        }
    }
}
