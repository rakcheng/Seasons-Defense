using System;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject sceneTransitionManager;
    public string playButtonLeadsTo;
    public TextMeshProUGUI highScoreText;
    
    public GameSO gameSo;
    
    
    public void Start()
    {
        AudioManager.Instance.Play("BackgroundMainMenu");
        PlayerPrefs.SetInt("Score", 0);
        highScoreText.SetText("High Score: " + PlayerPrefs.GetInt("HighScore", 0));
        InitGameSo();
    }

    public void PlayButton()
    {
        sceneTransitionManager.GetComponent<SceneTransition>().FadeTo(playButtonLeadsTo);
    }

    public void ExitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    private void InitGameSo()
    {
        gameSo.ScoreMultiplier = 1;
        gameSo.SpeedMultiplier = 1;

        gameSo.levelCount = 0;

        gameSo.enemyWaves = 2;
        gameSo.enemiesPerWave = 2;

        gameSo.missileWaves = 2;
        gameSo.missilesPerWave = 3;

        gameSo.towerAmmo = 15;
    }
}
