using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score = 0;

    public void AddScore(int score= 10)
    {
        Score += score;
    }
}
