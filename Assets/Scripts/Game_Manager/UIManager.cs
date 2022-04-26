using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
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

    //Score Board
    public TextMeshProUGUI score_Text;
    public void SetScore(int score)
    {
        score_Text.text = score.ToString();
    }

    //Game Over screen
    public GameObject gameover_Screen;
    public GameObject score_Board;
    public TextMeshProUGUI final_Score;
    public void Set_GameOver()
    {
        gameover_Screen.SetActive(true);
        score_Board.SetActive(false);
        final_Score.text += GameManager_Wolf.Instance.total_Score.ToString();
    }
}
