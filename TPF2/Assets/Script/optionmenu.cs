using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class optionmenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolumen(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
