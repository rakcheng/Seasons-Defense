using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyMissilePrefab;
    public GameObject smartBombPrefab;
    
    //Delay how fast the missiles Spawn
    public float delayMissileSpawn = 5f;

    private float yValue;




    void Start()
    {
        yValue = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        
        StartCoroutine(spawnEnemyMissile());
    }
    
    private IEnumerator spawnEnemyMissile()
    {
        Instantiate(enemyMissilePrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        //Instantiate(smartBombPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
    
        
        yield return new WaitForSeconds(delayMissileSpawn);
    }
}
