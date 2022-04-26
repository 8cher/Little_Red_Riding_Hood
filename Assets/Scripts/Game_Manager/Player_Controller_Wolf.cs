using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller_Wolf : Player_Controller
{
    private bool is_Boost = false;
    public float granny_Boost_Time;
    public float granny_Boost_Speed;
    [SerializeField]
    private GameObject granny_Wolf_Sprite;
    [SerializeField]
    private GameObject normal_Wolf_Sprite;

    public override void OnTriggerEnter(Collider other)
    {
        //  redhood hunter granny are in ai tag group
        if (other.CompareTag("AI") && !other.isTrigger)
        {
            Character_Info temp = other.GetComponent<Character_Info>();

            switch (temp.type)
            {
                case Character_Info.Character_Type.Red_Hood:
                    {
                        //add score to total score
                        //destroy character
                        //create a particle for character exit
                        GameManager_Wolf.Instance.Player_Catched_RedHood(temp.score);
                        Destroy(other.gameObject.transform.parent.gameObject);
                        Particle_Manager.Instance.Exit_Scene(other.gameObject.transform.position);
                        // Debug.Log("Player Wolf Trigger:Catch Red Hood");
                        break;
                    }
                case Character_Info.Character_Type.Hunter:
                    {
                        //if player has caught by hunter gameover
                        GameManager_Wolf.Instance.GameOver();
                        Debug.Log("Player Wolf Trigger:Catch Hunter");
                        break;
                    }
                case Character_Info.Character_Type.Granny:
                    {
                        //add score to total score
                        //destroy character
                        //create a particle for character exit
                        GameManager_Wolf.Instance.Player_Catched_Granny(temp.score);
                        Destroy(other.gameObject.transform.parent.gameObject);
                        Particle_Manager.Instance.Exit_Scene(other.gameObject.transform.position);
                        // Debug.Log("Player Wolf Trigger:Catch Granny");

                        //check if player is already boosted
                        if (is_Boost)
                        {
                            //if player has the boost, reset coroutine
                            StopAllCoroutines();
                            StartCoroutine(Granny_Boost_End());
                            Debug.Log("Reset Granny Boost Coroutine");
                        }
                        else
                        {
                            //if player isn't in boost
                            //set move speed to boost speed
                            //switch sprite to boost mode
                            //set boost bool
                            //and start coroutine to end boost after seconds
                            current_Speed = granny_Boost_Speed;
                            normal_Wolf_Sprite.SetActive(false);
                            granny_Wolf_Sprite.SetActive(true);
                            is_Boost = true;

                            StartCoroutine(Granny_Boost_End());
                            Debug.Log("Start Granny Boost");
                        }
                        break;
                    }
                default: break;
            }
        }
    }

    IEnumerator Granny_Boost_End()
    {
        yield return new WaitForSeconds(granny_Boost_Time);

        current_Speed = normal_Speed;
        normal_Wolf_Sprite.SetActive(true);
        granny_Wolf_Sprite.SetActive(false);
        is_Boost = false;
        Debug.Log("Boost End Coroutine Finished");
    }
}