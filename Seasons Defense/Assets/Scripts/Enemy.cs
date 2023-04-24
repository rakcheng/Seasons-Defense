using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyMissilePrefab;

    //Delay how fast the missiles Spawn
    public float delayMissileSpawn = 5f;

    public int enemyMissileCount = 3;
    void Start()
    {
        StartCoroutine(SpawnEnemyMissile());
    }
    
    private IEnumerator SpawnEnemyMissile()
    {
        while (enemyMissileCount > 0)
        {
            GameObject _missile = Instantiate(enemyMissilePrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            _missile.GetComponent<Missile>().SetTarget(SpawnManager.GetCivilizationVec3());
            yield return new WaitForSeconds(delayMissileSpawn);
            enemyMissileCount--;
        }
    }

    // method called when a missile destroys this enemy object
    // todo: add particle effects and/or animations to this method
    public void BeingDestroyed()
    {
        LevelManager.EnemiesCount--;
        LevelManager.EnemyDestroyed();
        Destroy(gameObject);
    }
}
