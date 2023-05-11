using UnityEngine;

public class TransitionHandler : MonoBehaviour
{
    public Animator initialSequenceAnimator;

    public void StartTransition()
    {
        initialSequenceAnimator.SetTrigger("GameEnded");
    }
}
