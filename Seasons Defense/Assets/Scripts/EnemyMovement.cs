using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //The speed of the enemies
    public float speed = 5f;
    public float rightPadding = 35f;
    public float leftPadding = -35f;
    //To be able to switch direction from left to right or right to left
    private bool _moveRight = true;

    void Start()
    {
        // Enemy will move right if it spawns on the left side of the screen
        _moveRight = transform.position.x < 0 ? true : false;
    }

    void Update()
    {
        //If the switchMovement is true it will move right
        if (_moveRight)
        {
            MoveEnemiesRight();
        }
        //If the switchMovement is false it will move left
        else
        {
            MoveEnemiesLeft();
        }
        
        // If Position x is beyond the padding bounds, the enemy will be de-spawned
        if (transform.position.x >= rightPadding || transform.position.x <= leftPadding)
        {
            LevelManager.Instance.enemiesCount--;
            LevelManager.Instance.EnemyDestroyed();
            Destroy(gameObject);
        }
    }
    
    void MoveEnemiesLeft()
    {
        transform.Translate(-speed*Time.deltaTime,0,0);
    }

    void MoveEnemiesRight()
    {
        transform.Translate(speed*Time.deltaTime,0,0);
    }
}
