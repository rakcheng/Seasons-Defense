using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MissileSpawner : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject enemyMissilePrefab;

    //Delay how fast the missiles Spawn
    public float delayMissileSpawn = 0f;
    [FormerlySerializedAs("enemyMissileCount")] 
    public float missilesToSpawn = 2;
    
    public int waveCount = 3;

    private float _missilesAtStart;
    

    void Start()
    {
        _missilesAtStart = missilesToSpawn;
        StartCoroutine(SpawnMissiles(delayMissileSpawn, enemyMissilePrefab));
    }

    private IEnumerator SpawnMissiles(float interval, GameObject missilePrefab)
    {

        LevelManager.Instance.finishedSpawningMissiles = false;
        LevelManager.Instance.enemyMissileCount = 0;
        
        while (waveCount > 0)
        {
            waveCount--;
            while (missilesToSpawn > 0)
            {
                LevelManager.Instance.enemyMissileCount++;
                missilesToSpawn--;

                //Chooses a random Spawn Point location for the enemy
                int randomSpawnPoint = Random.Range(0, spawnLocations.Length);
                GameObject missile = Instantiate(missilePrefab, spawnLocations[randomSpawnPoint].position, Quaternion.identity);
                missile.GetComponent<Missile>().SetTarget(SpawnManager.GetCivilizationVec3());
                if (missilesToSpawn > 0) yield return new WaitForSeconds(interval);
            }
            
            missilesToSpawn = ++_missilesAtStart;
            if (waveCount > 0) yield return new WaitForSeconds(7);
        }

        
        LevelManager.Instance.finishedSpawningMissiles = true;

        
    }

}
