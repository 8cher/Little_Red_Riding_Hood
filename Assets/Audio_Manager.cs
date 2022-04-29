using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio_Manager : MonoBehaviour
{
    public AudioMixer Total_Mixer;

    public void Set_BGM_Volume(float volume)
    {
        Total_Mixer.SetFloat("Volume_BGM", volume);
    }

    public void Set_SE_Volume(float volume)
    {
        Total_Mixer.SetFloat("Volume_SE", volume);
    }

    public void Set_Total_Volume(float volume)
    {
        Total_Mixer.SetFloat("Volume_Main", volume);
    }
}
