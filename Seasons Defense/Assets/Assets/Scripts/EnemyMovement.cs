using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //The speed of the enemies
    public float speed = 5f;

    //To be able to switch direction from left to right or right to left
    private bool switchMovement = true;

    void Update()
    {
        //If the switchMovement is true it will move right
        if (switchMovement)
        {
            moveEnemiesRight();
        }
        //If the switchMovement is false it will move left
        if (!switchMovement)
        {
            moveEnemiesLeft();
        }
        
        //If Postion x is greater than or equal to 11 it will change the switchMovement to false
        if (transform.position.x >= 11f)
        {
            switchMovement = false;
        }
        //If Postion x is less than or equal to negative 11 it will change the switchMovement to true
        if (transform.position.x <= -11f)
        {
            switchMovement = true;
        }
    }
    
    void moveEnemiesLeft()
    {
        transform.Translate(-speed*Time.deltaTime,0,0);
    }

    void moveEnemiesRight()
    {
        transform.Translate(speed*Time.deltaTime,0,0);
    }
}
