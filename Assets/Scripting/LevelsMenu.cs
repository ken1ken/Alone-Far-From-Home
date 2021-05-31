using UnityEngine;
using UnityEngine.SceneManagement; // need to use to  be able to change scenes

/** Services the new game (level choice) menu. */
public class LevelsMenu : MonoBehaviour
{
    private AsyncOperation preloadSplash;
    
    /**
     * Preload the loading screen so we do not get hung when loading the loading screen!
     */
    public void Start()
    {
        preloadSplash = SceneManager.LoadSceneAsync("Splash");
        preloadSplash.allowSceneActivation = false;
    }

    public void PlayEasyLevel()
    {
        DIFFICULTY.easyMode = true;
        Splash.NextScene = "SpaceStationGame";
        SceneManager.LoadScene("Splash");
        preloadSplash.allowSceneActivation = true;
    }
    
	public void PlayHardLevel()
    {
        DIFFICULTY.easyMode = false;
        Splash.NextScene = "SpaceStationGame";
        SceneManager.LoadScene("Splash");
        preloadSplash.allowSceneActivation = true;
    }
}
