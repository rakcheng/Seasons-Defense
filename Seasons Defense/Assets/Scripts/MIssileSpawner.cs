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
    [FormerlySerializedAs("enemyMissileCount")] public float missilesToSpawn = 10;

    
    void Start()
    {
        StartCoroutine(SpawnMissiles(delayMissileSpawn, enemyMissilePrefab));
    }

    private IEnumerator SpawnMissiles(float interval, GameObject missilePrefab)
    {
        LevelManager.Instance.finishedSpawningMissiles = false;
        LevelManager.Instance.enemyMissileCount = 0;
        
        while (missilesToSpawn > 0)
        {
            LevelManager.Instance.enemyMissileCount++;

            //Chooses a random Spawn Point location for the enemy
            int randomSpawnPoint = Random.Range(0, spawnLocations.Length);
            GameObject missile = Instantiate(missilePrefab, spawnLocations[randomSpawnPoint].position, Quaternion.identity);
            missile.GetComponent<Missile>().SetTarget(SpawnManager.GetCivilizationVec3());
            yield return new WaitForSeconds(interval);
            missilesToSpawn--;
        }

        LevelManager.Instance.finishedSpawningMissiles = true;
    }
}
