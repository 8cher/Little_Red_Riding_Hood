using UnityEngine;
using DG.Tweening;

public class Main_Menu_Panel_Animation : MonoBehaviour
{
    void Start()
    {
        transform.DOLocalMoveY(1314f, 0.3f, false).From();
    }
}