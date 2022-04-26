using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Destory : MonoBehaviour
{
    public void Destory_Particle()
    {
        Destroy(transform.parent.gameObject);
    }
}