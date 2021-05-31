using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    public PlayerCameraMovement playerMovement;
    public GameObject triggerGameSaveText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false); //disable puase menu UI
        Time.timeScale = 1f; //time back to normal 
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovement.cutscene = false;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true); //enable puase menu UI
        Time.timeScale = 0f; // freeze game
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        playerMovement.cutscene = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f; //to stop game being paused 
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        
        SceneManager.LoadScene("Menu");
    }

    public void Save()  // calls save function on player
    {
        playerMovement.SavePlayer();
        triggerGameSaveText.SetActive(true);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
