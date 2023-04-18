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

    public int enemyCount = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies(enemyInterval, enemiesPrefab));
    }

    private IEnumerator SpawnEnemies(float interval, GameObject[] enemy)
    {

        while (enemyCount > 0)
        {
            //Chooses a random Spawn Point location for the enemy
            int randomSpawnPoint = Random.Range(0, spawnLocations.Length);
            int i = Random.Range(0, enemy.Length);
            Instantiate(enemy[i], spawnLocations[randomSpawnPoint].position, Quaternion.identity);
            yield return new WaitForSeconds(interval);
            enemyCount--;
        }

    }
}
