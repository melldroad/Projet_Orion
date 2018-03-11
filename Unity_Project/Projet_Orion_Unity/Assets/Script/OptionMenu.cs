using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{

	public AudioMixer Mixer;
	
	public void SetVolume(float volume)
	{
		Mixer.SetFloat("MainVolume", volume);
		Debug.Log(volume);
	}

	public void SetQuality(int qualityLvl)
	{
		QualitySettings.SetQualityLevel(qualityLvl);
	}

	public void SetMusiqueVolume(float vol)
	{
		GameObject.Find("Musique").GetComponent<AudioSource>().volume = vol;
	}
}
