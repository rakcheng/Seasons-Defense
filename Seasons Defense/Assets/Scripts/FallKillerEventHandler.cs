using UnityEngine;

public class FallKillerEventHandler : MonoBehaviour
{
    public void AlertSceneTransition(string message)
    {
        if (message.Equals("KickAnimStarted")) LevelManager.Instance.NextLevel();
    }
}
