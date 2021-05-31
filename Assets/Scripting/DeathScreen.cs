using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ORIGINAL CODE
public class DeathScreen : MonoBehaviour
{
    public Image blackFade;
    public float targetTime = 20.0f;
    //Screen will fade black and stay black
    void Start()
    {
        blackFade.canvasRenderer.SetAlpha(0.0f);
        fadeIn();
    }

    // Update is called once per frame
    void fadeIn()
    {
        blackFade.CrossFadeAlpha(1, 2, false);
    }
}
