using UnityEngine;

public class FallTransitionHandler : MonoBehaviour
{
    public Animator mainCameraAnimator;
    public Animator killerTransformAnimator;
    public Animator killerModelAnimator;

    public void StartTransition()
    {
        mainCameraAnimator.enabled = true;
        killerTransformAnimator.enabled = true;
        killerModelAnimator.enabled = true;
    }
}
