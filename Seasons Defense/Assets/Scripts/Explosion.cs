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

        AudioManager.Instance.Play("Explosion");

        //Destroy the object, following a timer
        Destroy(gameObject, timeToDestroy);
    }

    private void FixedUpdate()
    {
        // Stores every thing that the ray has hit within the radius of the explosion

        // The 1 << 7 is the layer mask that only checks for other objects in that layer
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, transform.localScale.x, 1 << 7);

        foreach (var hit in hitColliders)
        {
            Debug.Log("Hit" + hit);
            ParseObjectHit(hit.gameObject);
        }
    }

    // Here is the method where we could parse through the different objects that get hit by the explosion
    private void ParseObjectHit(GameObject hit)
    {
        // If the hit is a player missile call to have it exploded then destroyed
        if (hit.GetComponent<Missile>())
        {
            hit.GetComponent<Missile>().BeingDestroyed();
        }

        // if a tower -> disable it 
        else if (hit.GetComponent<Tower>())
        {
            hit.GetComponent<Tower>().DisableTurret();
        }

        else if (hit.CompareTag("Enemy"))
        {
            hit.GetComponent<Enemy>().BeingDestroyed();
        }

        else if (hit.GetComponent<City>())
        {
            hit.GetComponent<City>().BeingDestroyed();
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
