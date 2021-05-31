using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
// CODE INSPIRED BY Brackeys: https://www.youtube.com/watch?v=XOjd_qU2Ido&t=1s&ab_channel=Brackeys
public static class SaveSystem
{
    public static void SavePlayer(PlayerCameraMovement player) // Saving game 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.affh";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer() // loading the save file game
    {
        string path = Application.persistentDataPath + "/player.affh";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
