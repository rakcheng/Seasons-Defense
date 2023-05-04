using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    public Animator cityAnimator;
    public GameObject cityDeathParticles;

    // todo: add particle effects and/or animation for this

    public void Start()
    {

    }

    public void BeingDestroyed()
    {
        GetComponent<Collider>().enabled = false;

        LevelManager.Instance.citiesCount--;
        LevelManager.Instance.BuildingDestroyed();
        
        cityAnimator.enabled = true;
        GameObject effect = Instantiate(cityDeathParticles, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        
        Destroy(gameObject, 2);
        
        
    }
}
