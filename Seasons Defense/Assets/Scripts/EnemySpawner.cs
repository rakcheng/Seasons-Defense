using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Using Waypoints to Plot Enemies Spawn Location
    public Transform[] spawnLocations;
    
    //Enemy Prefabs
    public GameObject[] enemiesPrefab;
    
    public int waveCount = 2;

    //How often the enemies will spawn in
    public float enemyInterval = 3f;

    public int enemyCount = 0;
    private int _enemyAtStart;

    public GameSO gameSo;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = gameSo.enemiesPerWave;
        waveCount = gameSo.enemyWaves;
        _enemyAtStart = enemyCount;
        StartCoroutine(SpawnEnemies(enemyInterval, enemiesPrefab));
    }

    private IEnumerator SpawnEnemies(float interval, GameObject[] enemy)
    {
        LevelManager.Instance.finishedSpawningEnemies = false;
        LevelManager.Instance.enemiesCount = 0;
        
        while(waveCount > 0)
        {
            waveCount--;
            while (enemyCount > 0)
            {
                LevelManager.Instance.enemiesCount++;
                enemyCount--;

                //Chooses a random Spawn Point location for the enemy
                int randomSpawnPoint = Random.Range(0, spawnLocations.Length);
                int i = Random.Range(0, enemy.Length);
                Instantiate(enemy[i], spawnLocations[randomSpawnPoint].position, Quaternion.identity);
                if (enemyCount > 0) yield return new WaitForSeconds(interval);
            }

            enemyCount = ++_enemyAtStart;
            if (waveCount > 0) yield return new WaitForSeconds(6);
        }

        LevelManager.Instance.finishedSpawningEnemies = true;

    }
}





