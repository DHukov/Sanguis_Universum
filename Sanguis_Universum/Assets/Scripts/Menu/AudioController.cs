using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioMixer MainMixer;
    public Slider SoundSlider;
    public Slider MusicSlider;

    public void setMusic()
    {
        float soundLvl = Mathf.Log10(MusicSlider.value) * 20;
        MainMixer.SetFloat("MusicVolume", soundLvl); 
    }

    public void setSound()
    {
        float masterLvl = Mathf.Log10(SoundSlider.value) * 20;
        MainMixer.SetFloat("SoundVolume", masterLvl);
        

    }
}
