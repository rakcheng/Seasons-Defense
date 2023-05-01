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
    public TextMeshProUGUI finalScoreText;

    private int _score = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = "SCORE: " + _score;
        highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    public void AddPoints(int points)
    {
        _score += points;
        PlayerPrefs.SetInt("Score", _score);
        scoreText.text = "SCORE: " + _score;
        if (PlayerPrefs.GetInt("HighScore", 0) < _score)
        {
            PlayerPrefs.SetInt("HighScore", _score);
        }
    }

    public void FinalScore()
    {
        finalScoreText.text = "FINAL SCORE: " + _score;
        PlayerPrefs.SetInt("Score", 0);
    }
}