using System;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject sceneTransitionManager;
    public string playButtonLeadsTo;
    public TextMeshProUGUI highScoreText;
    
    [SerializeField]
    private GameSO _multiplier;
    
    
    public void Start()
    {
        AudioManager.Instance.Play("BackgroundMainMenu");
        PlayerPrefs.SetInt("Score", 0);
        highScoreText.SetText("High Score: " + PlayerPrefs.GetInt("HighScore", 0));
        
        _multiplier.ScoreMultiplier = 1;
        _multiplier.SpeedMultiplier = 1;
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
}
