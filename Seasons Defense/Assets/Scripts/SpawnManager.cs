using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SpawnManager : MonoBehaviour
{
    private static Vector3[] _transformPositions;

    // Start is called before the first frame update
    
    void Awake()

    {
        InitializePositions();
    }

    public static Vector3 GetCivilizationVec3()
    {
        return _transformPositions[Random.Range(0, _transformPositions.Length)];
    }

    void InitializePositions()
    {
        GameObject[] civilizations = GameObject.FindGameObjectsWithTag("Civilization");
        _transformPositions = new Vector3[civilizations.Length];
        for (int i = 0; i < civilizations.Length; i++)
        {
            _transformPositions[i] = civilizations[i].transform.position;
        }
    }
    
}
