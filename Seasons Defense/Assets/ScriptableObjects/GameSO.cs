using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameSO : ScriptableObject
{
    public float speedMultiplier;
    public int scoreMultiplier;

    public int ScoreMultiplier
    {
        get => scoreMultiplier;
        set => scoreMultiplier = value;
    }
    
    public float SpeedMultiplier
    {
        get => speedMultiplier;
        set => speedMultiplier = value;
    }
}
