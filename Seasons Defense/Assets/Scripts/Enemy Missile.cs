using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    public GameObject explosionPrefab;
    
    GameObject[] civilizationPrefab;
    private Transform target;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        civilizationPrefab = GameObject.FindGameObjectsWithTag("Civilization");
        target = civilizationPrefab[Random.Range(0, civilizationPrefab.Length)].transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
    }
    
    private void Explode()
    {
        // Creates an explosion object at missile's location
        Instantiate(explosionPrefab);

        // Missile is no longer needed
        Destroy(gameObject);
    }
}
