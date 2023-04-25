using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    // todo: add particle effects and/or animation for this
    public void BeingDestroyed()
    {
        LevelManager.Instance.citiesCount--;
        LevelManager.Instance.BuildingDestroyed();
        Destroy(gameObject);
    }
}
