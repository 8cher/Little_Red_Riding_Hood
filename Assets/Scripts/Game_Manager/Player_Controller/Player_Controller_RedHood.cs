using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller_RedHood : Player_Controller
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AI") && !other.isTrigger)
        {
            Character_Info temp = other.GetComponent<Character_Info>();

            if (temp.type == Character_Info.Character_Type.Wolf)
            {
                GameManager_RedHood.Instance.GameOver();
                Debug.Log("Player RH Trigger:Catch Wolf");
            }
        }
    }
}