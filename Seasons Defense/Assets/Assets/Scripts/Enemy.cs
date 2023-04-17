using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyMissilePrefab;
    
    //Delay how fast the missiles Spawn
    public float delayMissileSpawn = 5f;


    


    void Start()
    {
        
        
        StartCoroutine(spawnEnemyMissile());
    }
    
    private IEnumerator spawnEnemyMissile()
    {
        Instantiate(enemyMissilePrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        
    
        
        yield return new WaitForSeconds(delayMissileSpawn);
    }
}
