using UnityEngine;

public class Missile : MonoBehaviour
{
    // Prefab definitions
    public GameObject explosionPrefab;

    //Reason to hide in inspector, is to force setting the target in code. 
    [HideInInspector]
    public Vector3 target;
    public float speed = 5;

    // This worth is changed for the Enemy Missile prefab
    public int worth = 0;
    
    public GameSO gameSo;

    
    private void Start()
    {
        if (!CompareTag("Player"))
            speed *= gameSo.SpeedMultiplier;
        transform.LookAt(target);
    }
    private void Update()
    {
        // Missile position will keep updating as it moves towards its target
        transform.position = Vector3.MoveTowards(transform.position, target, (speed) * Time.deltaTime);
        if (transform.position == target) Explode();
    }

    // Creates an explosion, which should handle damaging player structures itself
    // The missile is therefore just a vehicle for determining when/where to spawn an explosion, which actually does the real damage
    private void Explode()
    {
        GetComponent<Collider>().enabled = false;
        
        // Creates an explosion object at missile's location
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        if (!CompareTag("Player"))
        {
            LevelManager.Instance.enemyMissileCount--;
            LevelManager.Instance.EnemyDestroyed();
        }

        // Missile is no longer needed
        Destroy(gameObject);
    }

    public void SetTarget(Vector3 newTarget)
    {
        target = newTarget;
    }

    // method called when a missile destroys this missile object
    public void BeingDestroyed()
    {
        // In case of any missile exploding a player's missile, we don't assign points or imply enemy destruction
        if (!CompareTag("Player"))
        {
            ScoreManager.Instance.AddPoints(worth * gameSo.ScoreMultiplier);
        }

        Explode();
    }
}
