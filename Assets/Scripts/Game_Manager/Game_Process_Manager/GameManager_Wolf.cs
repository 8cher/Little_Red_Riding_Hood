using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Wolf : GameManager
{
    //redhood
    [Header("Red Hood")]
    public GameObject prefab_RedHood;
    public static int remaining_RedHood;
    private List<GameObject> redhoods;

    //granny
    [Header("Granny")]
    public GameObject prefab_Granny;
    public float granny_SpawnTime;
    public static int remaining_Granny;
    private bool first_Granny = false;

    //hunter
    [Header("Hunter")]
    public GameObject prefab_Hunter;
    public float hunter_SpawnTime;
    private bool first_Hunter = false;

    public override void Start()
    {
        base.Start();
        remaining_RedHood = 4;
        remaining_Granny = 0;
    }

    public override void GameLogic()
    {

        #region Red Hood Control Logic
        //Red Hood Part
        // at the beginning, have 4 redhood on stage
        // when redhood count is 2, spawn 2 new redhood
        if (remaining_RedHood == 2)
        {
            Tool_Method.Create_New_AI_Object(prefab_RedHood);
            remaining_RedHood += 1;
            Tool_Method.Create_New_AI_Object(prefab_RedHood);
            remaining_RedHood += 1;
        }
        #endregion
        #region Granny Control Logic
        //Granny Part
        // first granny will generated after a few seconds
        // when granny disapeared create a new one immediately
        if ((Timer.Instance.Spent_Duration() >= granny_SpawnTime) && !first_Granny)
        {
            Tool_Method.Create_New_AI_Object(prefab_Granny);
            first_Granny = true;
            remaining_Granny += 1;
        }
        if ((remaining_Granny == 0) && first_Granny)
        {
            Tool_Method.Create_New_AI_Object(prefab_Granny);
            remaining_Granny += 1;
        }
        #endregion
        #region Hunter Control Logic
        //Hunter Part
        // hunter will active in seconds at right bottom corner of the stage
        if ((Timer.Instance.Spent_Duration() >= hunter_SpawnTime) && !first_Hunter)
        {
            prefab_Hunter.SetActive(true);
        }
        #endregion
    }

    #region Method while player catched something
    public static void Player_Catched_RedHood(int score)
    {
        remaining_RedHood--;
        UI_Controller.Instance.AddScore(score);
    }
    public static void Player_Catched_Granny(int score)
    {
        remaining_Granny--;
        UI_Controller.Instance.AddScore(score);
    }
    #endregion
}