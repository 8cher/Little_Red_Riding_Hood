using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Controller : MonoBehaviour
{
    public static UI_Controller Instance;
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

    //Score Method
    public int total_Score = 0;
    public TextMeshProUGUI score_Text;
    public void AddScore(int score)
    {
        total_Score += score;
        score_Text.text = total_Score.ToString();
    }

    //Beginning Text Method
    public GameObject beginning_Text;
    public void Switch_Beginning_Text(bool state)
    {
        beginning_Text.SetActive(state);
    }

    //Game Over screen
    public GameObject gameover_Screen;
    public GameObject score_Board;
    public GameObject Timer_Panel;
    public TextMeshProUGUI final_Score;
    public void Set_GameOver()
    {
        gameover_Screen.SetActive(true);
        score_Board.SetActive(false);
        Timer_Panel.SetActive(false);
        final_Score.text += total_Score.ToString();
    }
}
