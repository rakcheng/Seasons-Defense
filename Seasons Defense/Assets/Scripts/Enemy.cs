using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyMissilePrefab;

    //Delay how fast the missiles Spawn
    public float delayMissileSpawn = 5f;
    public int enemyMissileCount = 3;

    public int worth = 100;
    void Start()
    {
        StartCoroutine(SpawnEnemyMissile());
    }
    
    private IEnumerator SpawnEnemyMissile()
    {
        while (enemyMissileCount > 0)
        {
            GameObject missile = Instantiate(enemyMissilePrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            missile.GetComponent<Missile>().SetTarget(SpawnManager.GetCivilizationVec3());
            //Increments Enemy Missile count when Spawned by enemy.
            LevelManager.Instance.enemyMissileCount++;
            yield return new WaitForSeconds(delayMissileSpawn);
            enemyMissileCount--;
        }
    }

    // method called when a missile destroys this enemy object
    // todo: add particle effects and/or animations to this method
    public void BeingDestroyed()
    {
        ScoreManager.Instance.AddPoints(worth);
        
        LevelManager.Instance.enemiesCount--;
        LevelManager.Instance.EnemyDestroyed();
        
        Destroy(gameObject);
    }
}
