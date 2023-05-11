using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameSO : ScriptableObject
{
    public int levelCount;
    
    public float speedMultiplier;
    public int scoreMultiplier;

    public int enemyWaves;
    public int enemiesPerWave;

    public int missileWaves;
    public int missilesPerWave;

    public int towerAmmo;

    public int LevelCount
    {
        get => levelCount;
        set => levelCount = value;
    }
    
    public int ScoreMultiplier
    {
        get => scoreMultiplier;
        set => scoreMultiplier = value;
    }
    
    public float SpeedMultiplier
    {
        get => speedMultiplier;
        set => speedMultiplier = value;
    }

    public int EnemyWaves
    {
        get => enemyWaves;
        set => enemyWaves = value;
    }
    
    public int EnemiesPerWave
    {
        get => enemiesPerWave;
        set => enemiesPerWave = value;
    }
    
    public int MissileWaves
    {
        get => missileWaves;
        set => missileWaves = value;
    }

    public int MissilesPerWave
    {
        get => missilesPerWave;
        set => missilesPerWave = value;
    }

    public int TowerAmmo
    {
        get => towerAmmo;
        set => towerAmmo = value;
    }
}
