using UnityEngine;

public class Missile : MonoBehaviour
{
    //Reason to hide in inspector, is to force setting the target in code. 
    [HideInInspector]
    public Vector3 target;
    public int speed = 5;

    private void Start()
    {
        transform.LookAt(target);
        
    }
    private void Update()
    {
        // Missile position will keep updating as it moves towards its target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == target) Destroy(gameObject);
    }

}
