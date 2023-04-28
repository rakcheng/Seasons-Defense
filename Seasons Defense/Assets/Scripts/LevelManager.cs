using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    // UI
    [Header("UI elements")]
    public GameObject gameOverUI;
    
    // Level switching functionality
    [Header("Level switching functionality")]
    public GameObject sceneTransitionManager;
    public string nextLevelSceneName;
    public string mainMenuSceneName;

    [Header("Game status variables")]
    public bool finishedSpawningEnemies;
    public bool finishedSpawningMissiles;
    public int enemyMissileCount;
    public int enemiesCount;

    // todo: These values are hard initialized temporarily
    public int citiesCount;
    public int towersCount;

    private bool _levelOver = false;
    
    /*
     * todo: add function to check for game-loss condition if the player runs out of ammo before end of level
     */

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        finishedSpawningEnemies = false;
        finishedSpawningMissiles = false;
        enemyMissileCount = 0;
        enemiesCount = 0;
        
        citiesCount = 6;
        towersCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitLevel()
    {
        sceneTransitionManager.GetComponent<SceneTransition>().FadeTo(mainMenuSceneName);
    }

    public void RetryLevel()
    {
        sceneTransitionManager.GetComponent<SceneTransition>().FadeTo(SceneManager.GetActiveScene().name);
    }

    public void EnemyDestroyed()
    {
        Debug.Log("Enemy destroyed.");
        if (LevelCompleted() && !_levelOver)
        {
            _levelOver = true;
            Debug.Log("Level won!");
            
        }
    }

    public void BuildingDestroyed()
    {
        Debug.Log("Building destroyed.");
        if (LevelLost() && !_levelOver)
        {
            _levelOver = true;
            
            // Show the game over UI elements
            gameOverUI.SetActive(true);
            ScoreManager.Instance.FinalScore();
            
            Debug.Log("Level lost!");
        }
    }

    // Level is won on the condition that the enemy missiles and enemies have all been spawned and then destroyed
    private bool LevelCompleted()
    {
        return finishedSpawningEnemies && finishedSpawningMissiles && enemiesCount <= 0 && enemyMissileCount <= 0;
    }

    // Level is lost on the condition that either all towers or cities have been destroyed
    private bool LevelLost()
    {
        return citiesCount <= 0 || towersCount <= 0;
    }
}
