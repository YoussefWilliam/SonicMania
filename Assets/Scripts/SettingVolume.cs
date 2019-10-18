using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
public class SettingVolume : MonoBehaviour
{
    public Slider sliderUI;
    public AudioMixer audioMixer;
    public void SetVolume()
    {
        audioMixer.SetFloat("Volume", sliderUI.value); 
    }
}
