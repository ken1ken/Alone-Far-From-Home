using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class OptionsMenu : MonoBehaviour
{
	public AudioMixer audioMixer; //reference to audio mixer
	public Slider volumeSlider;


	public void SetVolume (float volume)
	{
		
		audioMixer.SetFloat("volume",volume);	
	}
}
