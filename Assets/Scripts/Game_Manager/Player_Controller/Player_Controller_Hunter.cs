using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller_Hunter : Player_Controller
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AI") && !other.isTrigger)
        {
            Character_Info temp = other.GetComponent<Character_Info>();

            if (temp.type == Character_Info.Character_Type.Wolf)
            {
                GameManager_Hunter.Player_Catched_Wolf(temp.score);
                Destroy(other.gameObject.transform.parent.parent.gameObject);
                Particle_Manager.Instance.Exit_Scene(other.gameObject.transform.position);
                Debug.Log("Player Hunter Trigger:Catch Wolf");
            }
        }
    }
}