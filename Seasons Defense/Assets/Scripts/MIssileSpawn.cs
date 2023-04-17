using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawn : MonoBehaviour
{
    public Transform[] spawnLocations;

    public GameObject enemyMissilePrefab;

    //Delay how fast the missiles Spawn
    public float delayMissileSpawn = 5f;

    private float yValue;



    void Start()
    {
        StartCoroutine(missileSpawnRate(delayMissileSpawn, enemyMissilePrefab));
    }

    private IEnumerator missileSpawnRate(float interval, GameObject missiles)
    {
        yield return new WaitForSeconds(interval);

        //Chooses a random Spawn Point location for the enemy
        int randomSpawnPoint = Random.Range(0, spawnLocations.Length);
        GameObject _missiles = Instantiate(missiles, spawnLocations[randomSpawnPoint].position, Quaternion.identity);
        StartCoroutine(missileSpawnRate(interval, _missiles));

    }
}
