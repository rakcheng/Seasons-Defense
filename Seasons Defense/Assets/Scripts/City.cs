using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    public Animator cityAnimator;
    public GameObject cityDeathParticles;
    private bool _cityDestoyed;
    // todo: add particle effects and/or animation for this

    public void Start()
    {
        _cityDestoyed = false;
    }

    public void BeingDestroyed()
    {
        if (_cityDestoyed) return;

        GetComponent<Collider>().enabled = false;
        _cityDestoyed = true;
        
        LevelManager.Instance.citiesCount--;
        LevelManager.Instance.BuildingDestroyed();
        
        cityAnimator.enabled = true;
        GameObject effect = Instantiate(cityDeathParticles, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        
    }
}
