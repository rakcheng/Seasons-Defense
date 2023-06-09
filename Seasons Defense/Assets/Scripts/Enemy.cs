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

    public GameSO gameSo;
    void Start()
    {
        StartCoroutine(SpawnEnemyMissile());
    }
    
    private IEnumerator SpawnEnemyMissile()
    {
        while (enemyMissileCount > 0)
        {
            LevelManager.Instance.enemyMissileCount++;
            enemyMissileCount--;
            
            GameObject missile = Instantiate(enemyMissilePrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            missile.GetComponent<Missile>().SetTarget(SpawnManager.GetCivilizationVec3());
            if (enemyMissileCount > 0) yield return new WaitForSeconds(delayMissileSpawn);
        }

        GetComponent<EnemyMovement>().speed *= 3;
    }

    // method called when a missile destroys this enemy object
    // todo: add particle effects and/or animations to this method
    public void BeingDestroyed()
    {
        GetComponent<Collider>().enabled = false;
        ScoreManager.Instance.AddPoints(worth * gameSo.scoreMultiplier);
        
        LevelManager.Instance.enemiesCount--;
        LevelManager.Instance.EnemyDestroyed();

        GetComponent<Animator>().enabled = true;
    }

    public void DeathAnimationComplete()
    {
        Destroy(gameObject);
    }
}
