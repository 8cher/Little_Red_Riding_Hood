using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio_Controller : MonoBehaviour
{
    public AudioMixer audio_Mixer;
    private void Start()
    {
        audio_Mixer.SetFloat("Volume_Main", 1f);
        audio_Mixer.SetFloat("Volume_BGM", 1f);
        audio_Mixer.SetFloat("Volume_SE", 1f);
    }


    private void Update()
    {

    }
}
