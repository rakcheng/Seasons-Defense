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
        
        // Destroy the object, following a timer
        Destroy(gameObject, timeToDestroy);
    }
}
