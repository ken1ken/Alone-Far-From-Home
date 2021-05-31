using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BackgroundMusic : MonoBehaviour
{
    private AudioSource AudioSource; // define what audio we want to change the volume for
    public GameObject ObjectMusic;
    public Slider volumeSlider; // going to be used to save the slider value 


    private float musicVolume; // volume of audio soruce 
    private float defaultVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("BackgroundGameMusic");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

        musicVolume = PlayerPrefs.GetFloat("volume", defaultVolume);
        
        volumeSlider.value = musicVolume;
        AudioSource.volume = musicVolume;

    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = musicVolume;// we want to update the audio soruce varaiab
        PlayerPrefs.SetFloat("volume", musicVolume); //save musicVolume inside volume variable in memory so we can use it in next scene
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume; // audio source volume will be updated through the variable volume thats being patsed through
    }
}
