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
        LevelManager.Instance.finishedSpawningMissiles = false;
        LevelManager.Instance.enemyMissileCount = 0;
        
        while (enemyMissileCount > 0)
        {
            LevelManager.Instance.enemyMissileCount++;

            //Chooses a random Spawn Point location for the enemy
            int randomSpawnPoint = Random.Range(0, spawnLocations.Length);
            GameObject _missile = Instantiate(missile, spawnLocations[randomSpawnPoint].position, Quaternion.identity);
            _missile.GetComponent<Missile>().SetTarget(SpawnManager.GetCivilizationVec3());
            yield return new WaitForSeconds(interval);
            enemyMissileCount--;
        }

        LevelManager.Instance.finishedSpawningMissiles = true;
    }
}
