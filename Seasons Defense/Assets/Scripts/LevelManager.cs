using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

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
    
    [Header("End of Level Points")]
    public int cityWorth = 100;
    public int ammoWorth = 5;

    public TowerDecider towerDecider;

    [HideInInspector]
    public bool gameOver = false;

    private bool _levelOver = false;

    public GameSO gameSo;

    
    
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
            if (sceneTransitionManager.TryGetComponent(out TransitionHandler transitionHandler))
            {
                sceneTransitionManager.GetComponent<TransitionHandler>().StartTransition();
            }
            else
            {
                sceneTransitionManager.GetComponent<FallTransitionHandler>().StartTransition();
            }
            Debug.Log("Total Score " + ScoreManager.Instance.scoreText.text);
        }
    }

    public void BuildingDestroyed()
    {
        Debug.Log("Building destroyed.");
        if (LevelLost() && !_levelOver)
        {
            _levelOver = true;
            gameOver = true;
            
            // Show the game over UI elements
            gameOverUI.SetActive(true);
            
            ScoreManager.Instance.FinalScore();
            AudioManager.Instance.Play("DeathSound");
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

    public void NextLevel()
    {
        CitySurvivedPoints();
        AmmoUnusedPoints();
        UpdateSo();
        sceneTransitionManager.GetComponent<SceneTransition>().FadeTo(nextLevelSceneName);
    }

    private void UpdateSo()
    {
        gameSo.levelCount += 1;
        
        if (gameSo.levelCount % 2 == 0) // every 2 levels
        {
            gameSo.SpeedMultiplier += 0.1f;
        }

        if (gameSo.levelCount % 3 == 0) // every 3 levels
        {
            gameSo.enemiesPerWave += 1;
            gameSo.missilesPerWave += 1;
        }

        if (gameSo.levelCount % 4 == 0) // every 4 levels
        {
            gameSo.ScoreMultiplier += 1;
            
            gameSo.enemyWaves += 1;
        }

        if (gameSo.levelCount % 5 == 0) // every 5 levels
        {
            gameSo.towerAmmo += 5;
            
            gameSo.missileWaves += 1;
        }
    }

    private void CitySurvivedPoints()
    {
        ScoreManager.Instance.AddPoints(cityWorth * citiesCount * gameSo.scoreMultiplier);
    }

    private void AmmoUnusedPoints()
    {
        ScoreManager.Instance.AddPoints(ammoWorth * towerDecider.GetTotalAmmo() * gameSo.scoreMultiplier);
    }
}
