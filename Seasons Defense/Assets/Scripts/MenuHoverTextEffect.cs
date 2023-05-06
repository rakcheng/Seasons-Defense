using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHoverTextEffect : MonoBehaviour
{
    public GameObject button;
    public Vector3 BiggerSize;
    public Vector3 originalSize;

   public void makeTextBigger()
    {
        button.transform.localScale = BiggerSize;
    }

    public void makeTextOriginalSize()
    {
        button.transform.localScale = originalSize; 
    }
}
