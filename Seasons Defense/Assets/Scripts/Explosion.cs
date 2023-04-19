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
        
        // Begin timer to destroy game object
        StartCoroutine(DestroyExplosion());

    }

    private IEnumerator DestroyExplosion()
    {
        // Yield for timeToDestroy seconds
        yield return new WaitForSeconds(timeToDestroy);
        
        // Destroy the object
        Destroy(gameObject, timeToDestroy);
    }
}
