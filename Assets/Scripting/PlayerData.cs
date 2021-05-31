using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// CODE inspired by Brakeys: https://www.youtube.com/watch?v=XOjd_qU2Ido&t=1s&ab_channel=Brackeys
[System.Serializable]
public class PlayerData
{

    public string playerStage;
    public bool easyMode;
    public float[] playerPosition;
    public float[] monster1Position;
    public float[] monster2Position;
    public float[] danPosition;

    public bool HP1 = false;
    public bool HP2 = false;
    public bool HP3 = false;
    public bool HP4 = false;
    public bool HP5 = false;
    public bool HP6 = false;
    public bool HP7 = false;
    public bool HP8 = false;
    public bool HP9 = false;
    public bool HP10 = false;

    public PlayerData(PlayerCameraMovement player) // When saving, locations of player monsters and dan are stored.
    {
        playerStage = player.gameObject.tag;
        easyMode = DIFFICULTY.easyMode;

        playerPosition = new float[3];
        playerPosition[0] = player.transform.position.x;
        playerPosition[1] = player.transform.position.y;
        playerPosition[2] = player.transform.position.z;

        monster1Position = new float[3];
        monster1Position[0] = player.monster1.transform.position.x;
        monster1Position[1] = player.monster1.transform.position.y;
        monster1Position[2] = player.monster1.transform.position.z;

        monster2Position = new float[3];
        monster2Position[0] = player.monster2.transform.position.x;
        monster2Position[1] = player.monster2.transform.position.y;
        monster2Position[2] = player.monster2.transform.position.z;

        danPosition = new float[3];
        danPosition[0] = player.dan.transform.position.x;
        danPosition[1] = player.dan.transform.position.y;
        danPosition[2] = player.dan.transform.position.z;

        if (player.HP1.activeSelf) // The amount of hyodren packs collect will be saved.
        {
            HP1 = true;
        }

        if (player.HP2.activeSelf)
        {
            HP2 = true;
        }

        if (player.HP3.activeSelf)
        {
            HP3 = true;
        }

        if (player.HP4.activeSelf)
        {
            HP4 = true;
        }

        if (player.HP5.activeSelf)
        {
            HP5 = true;
        }

        if (player.HP6.activeSelf)
        {
            HP6 = true;
        }

        if (player.HP7.activeSelf)
        {
            HP7 = true;
        }

        if (player.HP8.activeSelf)
        {
            HP8 = true;
        }

        if (player.HP9.activeSelf)
        {
            HP9 = true;
        }

        if (player.HP10.activeSelf)
        {
            HP10 = true;
        }
    }

}
