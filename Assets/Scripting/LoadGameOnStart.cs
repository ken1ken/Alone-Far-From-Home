using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player object will check the value of gameSave at start of game.
public static class LoadGameOnStart
{
    public static bool gameSave = false;

    public static void loadSave()
    {
        gameSave = true;
    }
   
}

