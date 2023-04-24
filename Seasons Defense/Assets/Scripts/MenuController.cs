using System;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject sceneTransitionManager;
    public string playButtonLeadsTo;
    public TextMeshProUGUI highScoreText;

    public void Start()
    {
        highScoreText.SetText("High Score: " + PlayerPrefs.GetInt("HighScore"));
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
