using UnityEngine;

public class FallKillerEventHandler : MonoBehaviour
{
    public GameObject gameManager;

    public void AlertSceneTransition(string message)
    {
        if (message.Equals("KickAnimStarted")) gameManager.GetComponent<LevelManager>().NextLevel();
    }
}
