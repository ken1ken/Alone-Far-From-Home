using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
private void Awake()
    {
        // this will allow us to keep the audio source game object from Menu Scene to SpaceShipGame scene when we load
        // the SpaceShipGame Scene
        // that will be done by DontDestroyOnLoad(this.gameObject);
        // where it wont destroy th eaudio source but it will keep it playing from the first scene to the next
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("BackgroundGameMusic");
        if (musicObj.Length> 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject); 
    }
}
