using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class Button_Method : MonoBehaviour
{
    #region Start Panel
    public GameObject start_Panel;
    public GameObject credits_Panel;
    public GameObject select_Panel;

    //play button
    public void OnButtonClick_Play()
    {
        start_Panel.SetActive(false);
        select_Panel.SetActive(true);
    }

    //credits button & back

    public void OnButtonClick_Credits()
    {
        start_Panel.SetActive(false);
        credits_Panel.SetActive(true);
    }
    public void OnButtonClick_Exit_Credits()
    {
        start_Panel.SetActive(true);
        credits_Panel.SetActive(false);
    }

    //Exit button
    public static void OnButtonClick_Exit()
    {
        Application.Quit();
    }

    #endregion

    #region Game Mode Select

    //Scene redhood
    public static void On_Play_RH()
    {
        Debug.Log("Red Hood Mode Selected");
        DOTween.Clear(true);
        SceneManager.LoadScene("Scene_Redhood");
    }

    //Scene wolf
    public static void On_Play_Wolf()
    {
        Debug.Log("Wolf Mode Selected");
        DOTween.Clear(true);
        SceneManager.LoadScene("Scene_Wolf");
    }

    //Scene Hunter
    public static void On_Play_Hunter()
    {
        Debug.Log("Hunter Mode Selected");
        DOTween.Clear(true);
        SceneManager.LoadScene("Scene_Hunter");
    }

    #endregion

    //restart button
    public static void On_Restart()
    {
        Debug.Log("Restart Button Clicked");
        DOTween.Clear(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Back to menu Button
    public static void On_Back_2Menu()
    {
        Debug.Log("Back to menu Button Clicked");
        DOTween.Clear(true);
        SceneManager.LoadScene("MainScene");
    }
}
