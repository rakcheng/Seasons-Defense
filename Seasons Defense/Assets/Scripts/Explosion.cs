using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Reference to the animator responsible for the ExplosionBlast animation
    public Animator animator;
    // How long to wait before the Explosion game object should be destroyed
    public float timeToDestroy;

    private void Start()
    {
        // Play the explosion animation
        animator.Play("ExplosionBlast");

        //Destroy the object, following a timer
        Destroy(gameObject, timeToDestroy);
    }

    private void FixedUpdate()
    {
        // Stores every thing that the ray has hit within the radius of the explosion
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, transform.localScale.x, transform.up, 1);

        // iterates through every hit within the explosion max radius
        foreach (RaycastHit hit in hits)
        {
            // If statement is there so that the animation isn't taken into consideration
            if (hit.collider.gameObject.name != "BlastSphere")
                ParseObjectHit(hit);
        }
    }


    // Here is the method where we could parse through the different objects that get hit by the explosion
    private void ParseObjectHit(RaycastHit hit)
    {
        GameObject obj = hit.collider.gameObject;

        // If the hit is a player missile call to have it exploded then destroyed
        if (obj.GetComponent<Missile>())
        {
            obj.GetComponent<Missile>().BeingDestroyed();
        }
        
        // if a tower -> disable it 
        else if (obj.GetComponent<Tower>()) 
        {
            obj.GetComponent<Tower>().disableTurret();
        }
        
        else if (obj.CompareTag("Enemy"))
        {
            obj.GetComponent<Enemy>().BeingDestroyed();
        }
        
        else if (obj.GetComponent<City>())
        {
            obj.GetComponent<City>().BeingDestroyed();
        }

        // For right now, everything else gets destroyed
        // Destroy(obj);

    }

    // Used for testing purposes
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, transform.localScale.x);
    }
}


