using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Footstep : MonoBehaviour
{
    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.is_Game_Playing)
        {
            Debug.Log("Trigger Enter" + other.name);
            if (other.gameObject.CompareTag("Stage") && !source.isPlaying)
            {
                Debug.Log("Play audio");
                source.Play();
            }
        }
    }
}