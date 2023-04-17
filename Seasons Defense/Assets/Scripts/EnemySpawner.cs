using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Using Waypoints to Plot Enemies Spawn Location
    public Transform[] spawnLocations;
    
    //Enemy Prefabs
    public GameObject satellitesPrefab;
    public GameObject bomberPlanePrefab;

    //How often the enemies will spawn in
    public float satellitesInterval = 3f;
    public float bomberPlaneInterval = 15f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemyRate(satellitesInterval, satellitesPrefab));
        StartCoroutine(spawnEnemyRate(bomberPlaneInterval, bomberPlanePrefab));
    }

    private IEnumerator spawnEnemyRate(float interval, GameObject enemies)
    {
        yield return new WaitForSeconds(interval);
        
        //Chooses a random Spawn Point location for the enemy
        int randomSpawnPoint = Random.Range(0, spawnLocations.Length);
        GameObject enemy = Instantiate(enemies, spawnLocations[randomSpawnPoint].position,Quaternion.identity);
        StartCoroutine(spawnEnemyRate(interval, enemy));

    }
}
