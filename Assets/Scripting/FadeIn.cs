using UnityEngine;
using UnityEngine.UI;

//ORIGINAL CODE
public class FadeIn : MonoBehaviour
{
    public Image blackFade;
    public float targetTime = 20.0f;
    // Screen will fade black, then wait a few seconds, then fade back to normal
    void Start()
    {
        blackFade.canvasRenderer.SetAlpha(0.0f);
        fadeIn();
    }

    private void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            fadeOut();
        }
    }

    void fadeOut()
    {
        blackFade.CrossFadeAlpha(0, 2, false);
    }

    // Update is called once per frame
    void fadeIn()
    {
        blackFade.CrossFadeAlpha(1, 2, false);
    }
}
