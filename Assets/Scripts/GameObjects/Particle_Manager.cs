using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject particle_Enter;
    [SerializeField]
    private GameObject particle_Exit;

    public static Particle_Manager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    //Smoke effects when character enter the scene
    public void Enter_Scene(Vector3 pos)
    {
        Instantiate(particle_Enter, pos, Quaternion.identity).SetActive(true);
        Debug.Log("Particle Enter Generated At Position: " + pos);
    }

    //smoke effects when character exit the scene
    public void Exit_Scene(Vector3 pos)
    {
        Instantiate(particle_Exit, pos, Quaternion.identity).SetActive(true);
        Debug.Log("Particle Exit Generated At Position: " + pos);
    }
}