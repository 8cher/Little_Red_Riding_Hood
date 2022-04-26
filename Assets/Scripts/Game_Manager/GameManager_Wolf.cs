using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Wolf : MonoBehaviour
{
    private bool is_Game_Playing;
    private bool is_Game_Over;

    private float start_Time;
    public GameObject beginning_Text;
    [Header("Red Hood")]
    public GameObject prefab_RedHood;
    public int remaining_RedHood;
    private List<GameObject> redhoods;
    [Header("Granny")]
    public GameObject prefab_Granny;
    public float granny_SpawnTime;
    public int remaining_Granny;
    private bool first_Granny = false;
    [Header("Hunter")]
    public GameObject hunter;
    public float hunter_SpawnTime;
    [Header("Score")]
    private bool first_Hunter = false;

    public static GameManager_Wolf Instance;
    private void Awake()
    {
        #region Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        #endregion
    }

    private void Start()
    {
        Time.timeScale = 0f;
        start_Time = Time.time;
        is_Game_Playing = false;
        is_Game_Over = false;
        beginning_Text.SetActive(true);
    }

    private void Update()
    {
        //before game start, timescale is 0 and bool is false
        if (!is_Game_Playing && !is_Game_Over && Input.anyKeyDown)
        {
            is_Game_Playing = true;
            Time.timeScale = 1f;
            beginning_Text.SetActive(false);
        }
        if (is_Game_Playing)
        {
            #region Red Hood Control Logic
            //Red Hood Part
            // at the beginning, have 4 redhood on stage
            // when redhood count is 2, spawn 2 new redhood
            if (remaining_RedHood == 2)
            {
                Create_New_AI_Object(prefab_RedHood);
                remaining_RedHood += 1;
                Create_New_AI_Object(prefab_RedHood);
                remaining_RedHood += 1;
            }
            #endregion
            #region Granny Control Logic
            //Granny Part
            // first granny will generated after a few seconds
            // when granny disapeared create a new one immediately
            if (((Time.time - start_Time) >= granny_SpawnTime) && !first_Granny)
            {
                Create_New_AI_Object(prefab_Granny);
                first_Granny = true;
                remaining_Granny += 1;
            }
            if ((remaining_Granny == 0) && first_Granny)
            {
                Create_New_AI_Object(prefab_Granny);
                remaining_Granny += 1;
            }
            #endregion
            #region Hunter Control Logic
            //Hunter Part
            // hunter will active in seconds at right bottom corner of the stage
            if (((Time.time - start_Time) >= hunter_SpawnTime) && !first_Hunter)
            {
                hunter.SetActive(true);
            }
            #endregion
            //Timer Part
            // if time count down finished,set Gameover
            if (Timer.Instance.Remaining_Duration() >= 0)
            {
                GameOver();
            }
        }
    }

    /// <summary>
    /// Create a prefab at random position in navmesh data
    /// </summary>
    /// <param name="prefab">Gameobject to create</param>
    private void Create_New_AI_Object(GameObject prefab)
    {
        Vector3 temp_Pos = Tool_Method.Get_Random_Location();
        Instantiate(prefab, temp_Pos, Quaternion.identity).SetActive(true);

        Debug.Log("Generated Object: " + prefab.ToString() + "At Position: " + temp_Pos);
        Particle_Manager.Instance.Enter_Scene(temp_Pos);
    }

    #region Score Count and Update
    public int total_Score = 0;

    private void AddScore(int score)
    {
        total_Score += score;
        UIManager.Instance.SetScore(total_Score);
    }
    public void Player_Catched_RedHood(int score)
    {
        remaining_RedHood--;
        AddScore(score);
    }
    public void Player_Catched_Granny(int score)
    {
        remaining_Granny--;
        AddScore(score);
    }
    #endregion

    #region Game Over Functions
    public void GameOver()
    {
        Time.timeScale = 0f;
        UIManager.Instance.Set_GameOver();
        is_Game_Playing = false;
        is_Game_Over = true;
    }
    #endregion
}