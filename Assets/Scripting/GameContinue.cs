using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // need to use to  be able to change scenes
//Once the player has selected load, the game varible in LadGameOnStart will be set to true, this causes the game to load a save as soon as it starts.
//ORIGINAL CODE
public class GameContinue : MonoBehaviour
{
    private AsyncOperation preloadSplash;

    public void Start()
    {
        Splash.NextScene = "SpaceStationGame";
        preloadSplash = SceneManager.LoadSceneAsync("Splash");
        preloadSplash.allowSceneActivation = false;
    }

    public void PlayEasyLevel()
    {
        DIFFICULTY.easyMode = true;
        SceneManager.LoadScene("Splash");
        preloadSplash.allowSceneActivation = true;
        LoadGameOnStart.loadSave();
    }

    public void PlayHardLevel()
    {
        SceneManager.LoadScene("Splash");
        preloadSplash.allowSceneActivation = true;
    }
}
