using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static bool FinishedSpawningEnemies;
    public static bool FinishedSpawningMissiles;
    public static int EnemyMissileCount;
    public static int EnemiesCount;

    // todo: These values are hard initialized temporarily
    public static int CitiesCount;
    public static int TowersCount;

    // Start is called before the first frame update
    void Start()
    {
        FinishedSpawningEnemies = false;
        FinishedSpawningMissiles = false;
        EnemyMissileCount = 0;
        EnemiesCount = 0;

        CitiesCount = 6;
        TowersCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void EnemyDestroyed()
    {
        Debug.Log("Enemy destroyed.");
        if (LevelCompleted())
        {
            Debug.Log("Level won!");
        }
    }

    public static void BuildingDestroyed()
    {        
        Debug.Log("Building destroyed.");
        if (LevelLost())
        {
            Debug.Log("Level lost!");
        }
    }

    // Level is won on the condition that the enemy missiles and enemies have all been spawned and then destroyed
    private static bool LevelCompleted()
    {
        return FinishedSpawningEnemies && FinishedSpawningMissiles && EnemiesCount <= 0 && EnemyMissileCount <= 0;
    }

    // Level is lost on the condition that either all towers or cities have been destroyed
    private static bool LevelLost()
    {
        return CitiesCount <= 0 || TowersCount <= 0;
    }
}
