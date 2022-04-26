using UnityEngine;
using DG.Tweening;

public class Main_Menu_Wolf_Cutoff_Animation : MonoBehaviour
{
    void Start()
    {
        transform.DORestart();
        transform.DOMoveY(150f, 0.75f, false).SetLoops(-1, LoopType.Yoyo);
        transform.DOMoveX(4000f, 10f, false).SetLoops(-1, LoopType.Restart);
    }
}