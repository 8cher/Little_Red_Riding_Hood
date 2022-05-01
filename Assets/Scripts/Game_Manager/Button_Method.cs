using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class Button_Method : MonoBehaviour
{
    public AudioSource audio_Source;

    #region Start Panel
    public GameObject start_Panel;
    public GameObject credits_Panel;
    public GameObject select_Panel;

    //play button
    public void OnButtonClick_Play()
    {
        audio_Source.Play();
        start_Panel.SetActive(false);
        select_Panel.SetActive(true);
    }

    //credits button & back

    public void OnButtonClick_Credits()
    {
        audio_Source.Play();
        start_Panel.SetActive(false);
        credits_Panel.SetActive(true);
    }
    public void OnButtonClick_Exit_Credits()
    {
        audio_Source.Play();
        start_Panel.SetActive(true);
        credits_Panel.SetActive(false);
    }

    //Exit button
    public void OnButtonClick_Exit()
    {
        audio_Source.Play();
        Application.Quit();
    }

    #endregion

    #region Game Mode Select

    //Scene redhood
    public void OnButtonClick_Play_RH()
    {
        audio_Source.Play();
        Debug.Log("Red Hood Mode Selected");
        DOTween.Clear(true);
        SceneManager.LoadScene("Scene_Redhood");
    }

    //Scene wolf
    public void OnButtonClick_Play_Wolf()
    {
        audio_Source.Play();
        Debug.Log("Wolf Mode Selected");
        DOTween.Clear(true);
        SceneManager.LoadScene("Scene_Wolf");
    }

    //Scene Hunter
    public void OnButtonClick_Play_Hunter()
    {
        audio_Source.Play();
        Debug.Log("Hunter Mode Selected");
        DOTween.Clear(true);
        SceneManager.LoadScene("Scene_Hunter");
    }

    #endregion

    //restart button
    public void OnButtonClick_Restart()
    {
        audio_Source.Play();
        Debug.Log("Restart Button Clicked");
        DOTween.Clear(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Back to menu Button
    public GameObject background_Music;
    public void OnButtonClick_Back2Menu()
    {
        audio_Source.Play();
        Debug.Log("Back to menu Button Clicked");
        DOTween.Clear(true);
        Destroy(GameObject.Find("BGM"));
        SceneManager.LoadScene("MainScene");
    }
}
