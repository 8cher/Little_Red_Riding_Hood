using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Info : MonoBehaviour
{
    public int score;
    public Character_Type type;
    public enum Character_Type
    {
        Wolf,
        Red_Hood,
        Hunter,
        Granny
    }
}
