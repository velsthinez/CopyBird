using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private ScoreManager _scoreManager;
    private GameManager _gameManager;
    
    public TMP_Text ScoreUI;
    public TMP_Text EndScoreUI;

    public GameObject ScorePanel;
    public GameObject EndPanel;

    private bool gameStarted = false;

    private GameManager.GameStatus internalProgress = GameManager.GameStatus.Beginning;
    
    // Start is called before the first frame update
    void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _gameManager = FindObjectOfType<GameManager>();
        
        ScorePanel.SetActive(false);
        EndPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUIPanels();
        
        if (_scoreManager == null)
            return;

        ScoreUI.text = _scoreManager.Score.ToString();
    }

    void UpdateUIPanels()
    {
        if (_gameManager == null )
            return;

        switch (_gameManager.GameProgress)
        {
            case GameManager.GameStatus.Beginning:
                if (internalProgress != GameManager.GameStatus.Beginning)
                {
                    internalProgress = GameManager.GameStatus.Beginning;
                    ScorePanel.SetActive(false);
                    EndPanel.SetActive(false);
                    gameStarted = false;
                }
                break;
            case GameManager.GameStatus.InProgress:
                if (internalProgress != GameManager.GameStatus.InProgress)
                {
                    internalProgress = GameManager.GameStatus.InProgress;
                    ScorePanel.SetActive(true);
                    EndPanel.SetActive(false);

                    gameStarted = true;
                }
                break;
            case GameManager.GameStatus.Ended:
                if (internalProgress != GameManager.GameStatus.Ended)
                {
                    internalProgress = GameManager.GameStatus.Ended;
                    ScorePanel.SetActive(false);
                    EndPanel.SetActive(true);

                    EndScoreUI.text = _scoreManager.Score.ToString();;
                }
                break;
        }
    }
}
