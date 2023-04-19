using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MissileSpawner : MonoBehaviour
{
    public Transform[] spawnLocations;

    public GameObject enemyMissilePrefab;

    //Delay how fast the missiles Spawn
    public float delayMissileSpawn = 5f;

    public float enemyMissileCount = 10;
    

    void Start()
    {
        StartCoroutine(SpawnMissiles(delayMissileSpawn, enemyMissilePrefab));
    }

    private IEnumerator SpawnMissiles(float interval, GameObject missile)
    {

        while (enemyMissileCount > 0)
        {
            //Chooses a random Spawn Point location for the enemy
            int randomSpawnPoint = Random.Range(0, spawnLocations.Length);
            GameObject _missile = Instantiate(missile, spawnLocations[randomSpawnPoint].position, Quaternion.identity);
            yield return new WaitForSeconds(interval);
            enemyMissileCount--;
        }

    }
}
