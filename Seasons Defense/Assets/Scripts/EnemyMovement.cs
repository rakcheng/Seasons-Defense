using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //The speed of the enemies
    public float speed = 5f;

    public bool faceMatters = false;

    private const float RightPadding = 20f;
    private const float LeftPadding = -20f;
    
    //To be able to switch direction from left to right or right to left
    private bool _moveRight = true;
    
    [SerializeField]
    private GameSO _multiplier;

    void Start()
    {
        // Enemy will move right if it spawns on the left side of the screen
        _moveRight = transform.position.x < 0;

        if (faceMatters) ChangeFace();
    }

    void Update()
    {
        if (faceMatters || _moveRight)
        {
            MoveEnemyRight();
        }
        else
        {
            MoveEnemyLeft();
        }
        
        // If Position x is beyond the padding bounds, the enemy will be de-spawned
        if (transform.position.x >= RightPadding || transform.position.x <= LeftPadding)
        {
            LevelManager.Instance.enemiesCount--;
            LevelManager.Instance.EnemyDestroyed();
            Destroy(gameObject);
        }
    }
    
    void MoveEnemyLeft()
    {
        transform.Translate((-speed * _multiplier.SpeedMultiplier)*Time.deltaTime,0,0);
    }

    void MoveEnemyRight()
    {
        transform.Translate((speed * _multiplier.SpeedMultiplier)*Time.deltaTime,0,0);
    }

    void ChangeFace()
    {
        if (!_moveRight)
        {
            // Get the current rotation of the object
            Vector3 currentRotation = transform.rotation.eulerAngles;

            // Calculate the new rotation by adding 180 degrees to the current Y-axis rotation
            Vector3 newRotation = new Vector3(currentRotation.x, currentRotation.y + 180f, currentRotation.z);

            // Apply the new rotation to the object
            transform.rotation = Quaternion.Euler(newRotation);
        }
    }
}
