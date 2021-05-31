using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public GameObject loadButton; //reference to load button
	public GameObject loadButtonBlack; // reference to black load button
	public void Start()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		//MainMenuCheckSave.checkSave();
		checkSave();
	}

	public void Quit(){
#if UNITY_EDITOR
		// Application.Quit() does not work in the editor so
		// UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
	public void checkSave()
    {
		string path = Application.persistentDataPath + "/player.affh";
		if (File.Exists(path))
		{
			
			loadButton.SetActive(true);
		}
		else
		{
			loadButtonBlack.SetActive(true);
		}
	}
}
