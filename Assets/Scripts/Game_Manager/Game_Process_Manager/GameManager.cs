using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //game process judgment
    public bool is_Game_Playing;
    private bool is_Game_Over;

    public static GameManager Instance;
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

    public virtual void Start()
    {
        Time.timeScale = 0f;
        is_Game_Playing = false;
        is_Game_Over = false;
        UI_Controller.Instance.Switch_Beginning_Text(true);
    }

    private void Update()
    {
        //before game start, timescale is 0 and bool is false
        if (!is_Game_Playing && !is_Game_Over && Input.anyKeyDown)
        {
            is_Game_Playing = true;
            Time.timeScale = 1f;
            UI_Controller.Instance.Switch_Beginning_Text(false);
        }
        if (is_Game_Playing)
        {
            GameLogic();
            if (Timer.Instance.Remaining_Duration() >= 0)
            {
                GameOver();
            }
        }
    }

    public virtual void GameLogic() { }

    public void GameOver()
    {
        Time.timeScale = 0f;
        Final_Score_Add();
        UI_Controller.Instance.Set_GameOver();
        is_Game_Playing = false;
        is_Game_Over = true;
    }

    public virtual void Final_Score_Add() { }
}