using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextureFader : MonoBehaviour
{
    public float fadeDuration = 1f; // Duration of the fade effect
    public float pauseDuration = 8f; 
    public Texture2D[] backgrounds; 
    private RawImage mainMenuBackground; 
    private int currentIndex = 0; 


    
    void Start()
    {
        mainMenuBackground = GetComponent<RawImage>();
        mainMenuBackground.texture = backgrounds[backgrounds.Length - 1];
        StartCoroutine(SwitchTextures());
    }

    IEnumerator SwitchTextures()
    {
        while (true)
        {
            yield return new WaitForSeconds(pauseDuration);
            yield return StartCoroutine(Fade(1, 0)); // Fade out image
            mainMenuBackground.texture = backgrounds[currentIndex]; 
            currentIndex = (currentIndex + 1) % backgrounds.Length;
            yield return StartCoroutine(Fade(0,1)); // Fade in image
            
        }
    }

    IEnumerator Fade(float startVal, float endVal)
    {
        float elapsedTime = 0.0f;
        Color color = mainMenuBackground.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startVal, endVal, elapsedTime / fadeDuration);
            mainMenuBackground.color = color;
            yield return null;
        }
    }

    
}

