using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
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

    [SerializeField]
    private float time_Countdown;
    private float start_Time;
    private float end_Time;

    void Start()
    {
        start_Time = Time.time;
        end_Time = start_Time + time_Countdown;
    }

    void Update()
    {
        Set_Time(Remaining_Duration());
    }

    /// <summary>
    /// shows remaining duration
    /// </summary>
    /// <returns>Remaining Duration. If value >=0 means time is over.</returns>
    public int Remaining_Duration()
    {
        return (int)(Time.time - end_Time);
    }

    public TextMeshProUGUI timer_Time_Text;
    private void Set_Time(float float_Time)
    {
        int int_Time = Mathf.Abs((int)float_Time);
        timer_Time_Text.text = int_Time.ToString();
    }
}
