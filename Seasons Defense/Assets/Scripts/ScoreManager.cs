using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int _score = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        scoreText.text = "SCORE: " + _score;
        highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    public void AddPoints(int points)
    {
        _score += points;
        scoreText.text = "SCORE: " + _score;
        if (PlayerPrefs.GetInt("HighScore", 0) < _score)
        {
            PlayerPrefs.SetInt("HighScore", _score);
        }
    }
}