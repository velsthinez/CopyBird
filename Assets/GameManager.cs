using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public enum GameStatus
    {
        Beginning,
        InProgress,
        Ended
    }
    
    public GameStatus GameProgress = GameStatus.Beginning;

    private void Start()
    {
        GameProgress = GameStatus.InProgress;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && GameProgress == GameStatus.Ended)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    public void GameEnded()
    {
        GameProgress = GameStatus.Ended;
    }
}
