using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }
    
    IEnumerator FadeIn()
    {
        AudioSource backgroundAudio;
        if (SceneManager.GetActiveScene().name == "MainMenu")
            backgroundAudio = AudioManager.Instance.GetComponents<AudioSource>()[1];
        else
            backgroundAudio = AudioManager.Instance.GetComponents<AudioSource>()[2];
        
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(img.color.r, img.color.g, img.color.b, a);
            backgroundAudio.volume = 1 - a;
            yield return 0;
        }
    }
    
    IEnumerator FadeOut(string scene)
    {
        AudioSource backgroundAudio;
        if (SceneManager.GetActiveScene().name == "MainMenu")
            backgroundAudio = AudioManager.Instance.GetComponents<AudioSource>()[1];
        else
            backgroundAudio = AudioManager.Instance.GetComponents<AudioSource>()[2];
        
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(img.color.r, img.color.g, img.color.b, a);
            backgroundAudio.volume = 1 - a;
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
