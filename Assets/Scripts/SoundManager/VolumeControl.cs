using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;

    public void SetVolume()
    {
        Debug.Log("Playsound");
        mixer.SetFloat("volume", volumeSlider.value);
    }
}
