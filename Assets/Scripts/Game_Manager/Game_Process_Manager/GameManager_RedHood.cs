using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_RedHood : GameManager
{
    //gameobject
    public GameObject prefab_Wolf;
    private int remaining_Wolf;
    [SerializeField]
    private GameObject player;

    public override void Start()
    {
        remaining_Wolf = 0;
    }

    public override void GameLogic()
    {
        if ((Timer.Instance.Spent_Duration() >= 0) && remaining_Wolf == 0)
        {
            Tool_Method.Create_New_AI_Object(prefab_Wolf, Check_Generate_Position(new Vector3(3f, 0f, 2f)));
            remaining_Wolf += 1;
        }
        if ((Timer.Instance.Spent_Duration() >= 10) && remaining_Wolf == 1)
        {
            Tool_Method.Create_New_AI_Object(prefab_Wolf, Check_Generate_Position(new Vector3(3f, 0f, 2f)));
            remaining_Wolf += 1;
        }
        if ((Timer.Instance.Spent_Duration() >= 30) && remaining_Wolf == 2)
        {
            Tool_Method.Create_New_AI_Object(prefab_Wolf, Check_Generate_Position(new Vector3(3f, 0f, 2f)));
            remaining_Wolf += 1;
        }
        if ((Timer.Instance.Spent_Duration() >= 50) && remaining_Wolf == 3)
        {
            Tool_Method.Create_New_AI_Object(prefab_Wolf, Check_Generate_Position(new Vector3(3f, 0f, 2f)));
            remaining_Wolf += 1;
        }
    }

    private Vector3 Check_Generate_Position(Vector3 v3)
    {
        if (player.transform.position.x >= 0)
        { v3.x = -v3.x; }
        if (player.transform.position.z >= 0)
        { v3.z = -v3.z; }
        return v3;
    }

    public override void Final_Score_Add()
    {
        UI_Controller.Instance.AddScore((Timer.Instance.Spent_Duration() + 1) * 100);
    }
}