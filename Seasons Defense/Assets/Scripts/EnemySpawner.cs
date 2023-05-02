using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Using Waypoints to Plot Enemies Spawn Location
    public Transform[] spawnLocations;
    
    //Enemy Prefabs
    public GameObject[] enemiesPrefab;

    //How often the enemies will spawn in
    public float enemyInterval = 3f;

    public int enemyCount = 0;
    private int _enemyAtStart;

    private int _waveCount = 2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _enemyAtStart = enemyCount;
        StartCoroutine(SpawnEnemies(enemyInterval, enemiesPrefab));
    }

    private IEnumerator SpawnEnemies(float interval, GameObject[] enemy)
    {
        LevelManager.Instance.finishedSpawningEnemies = false;
        LevelManager.Instance.enemiesCount = 0;
        
        while(_waveCount > 0)
        {
            _waveCount--;
            while (enemyCount > 0)
            {
                LevelManager.Instance.enemiesCount++;

                //Chooses a random Spawn Point location for the enemy
                int randomSpawnPoint = Random.Range(0, spawnLocations.Length);
                int i = Random.Range(0, enemy.Length);
                Instantiate(enemy[i], spawnLocations[randomSpawnPoint].position, Quaternion.identity);
                yield return new WaitForSeconds(interval);
                enemyCount--;
            }

            enemyCount = ++_enemyAtStart;
            yield return new WaitForSeconds(9);
        }

        LevelManager.Instance.finishedSpawningEnemies = true;

    }
}





