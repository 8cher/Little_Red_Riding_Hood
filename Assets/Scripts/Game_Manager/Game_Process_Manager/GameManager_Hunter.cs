using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Hunter : GameManager
{
    //gameobject
    [SerializeField]
    private GameObject prefab_RH;
    public GameObject container_RH;
    public static int remaining_RedHood;
    public static List<GameObject> list_Red_Hood = new List<GameObject>(4);
    public static int remaining_Wolf;
    public GameObject prefab_Wolf;
    [SerializeField]
    private GameObject player;

    public override void Start()
    {
        base.Start();
        remaining_RedHood = 4;
        remaining_Wolf = 4;

        //store all rh into a list
        for (int i = 0; i < container_RH.transform.childCount; i++)
        {
            GameObject temp_OBJ = container_RH.transform.GetChild(i).gameObject;
            list_Red_Hood.Add(temp_OBJ);
            Debug.Log(list_Red_Hood);
        }
    }

    public override void GameLogic()
    {
        if (remaining_Wolf <= 3)
        {
            Tool_Method.Create_New_AI_Object(prefab_Wolf, Check_Generate_Position(new Vector3(3f, 0f, 2f)));
            remaining_Wolf += 1;
        }

        //when remaining redhood is 0, gameover
        if (remaining_RedHood == 0)
        {
            Instance.GameOver();
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

    #region Method while player catched something
    public static void Player_Catched_Wolf(int score)
    {
        remaining_Wolf--;
        UI_Controller.Instance.AddScore(score);
    }
    #endregion

    public override void Final_Score_Add()
    {
        UI_Controller.Instance.AddScore(remaining_RedHood * 1000);
    }
}