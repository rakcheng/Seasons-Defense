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
        //If the switchMovement is true it will move right
        if (transform.position.x < 0)
        {
            _moveRight = true;
        }
        //If the switchMovement is false it will move left
        else
        {
            _moveRight = false;
        }
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
        
        //If Postion x is greater than or equal to 11 it will change the switchMovement to false
        if (transform.position.x >= rightPadding)
        {
            LevelManager.EnemiesCount--;
            LevelManager.EnemyDestroyed();
            Destroy(gameObject);
        }
        //If Postion x is less than or equal to negative 11 it will change the switchMovement to true
        if (transform.position.x <= leftPadding)
        {
           
            LevelManager.EnemiesCount--;
            LevelManager.EnemyDestroyed();
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
