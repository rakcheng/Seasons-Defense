using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterTransitionTiming : MonoBehaviour
{
    public Animator SnowAnimator;

    public void TriggerSnowstorm()
    {
        SnowAnimator.SetTrigger("Trigger");
    }

    public void TriggerNextLevel()
    {
        LevelManager.Instance.NextLevel();
    }
}
