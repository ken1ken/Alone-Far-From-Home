using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
// CODE INSPIRED BY Brackeys: https://www.youtube.com/watch?v=XOjd_qU2Ido&t=1s&ab_channel=Brackeys
public static class MainMenuCheckSave
{
    public static void checkSave() // loading the save file game
    {
        string path = Application.persistentDataPath + "/player.affh";
        if (File.Exists(path))
        {
            Debug.Log("save exist");
            //loadButton.SetActive(true);
        }
        else
        {
            Debug.Log("save does not exist");
            //loadButton.SetActive(false);
        }
    }
}