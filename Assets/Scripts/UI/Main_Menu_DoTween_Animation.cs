using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Main_Menu_DoTween_Animation : MonoBehaviour
{
    public GameObject image_RH;
    public GameObject image_Wolf;
    public GameObject panel;
    void Awake()
    {
        Time.timeScale = 1f;
    }
    void Start()
    {
        //Menu Enter
        panel.transform.DOLocalMoveY(1314f, 0.3f, false).From();
        //RH rotate
        image_RH.transform.DOShakeRotation(1f, new Vector3(0, 0, 10), 4, 180, false).SetLoops(-1, LoopType.Incremental);
        //Wolf shake and move
        image_Wolf.transform.DOMoveY(-500f, 0.75f, false).SetLoops(-1, LoopType.Yoyo);
        image_Wolf.transform.DOMoveX(4000f, 10f, false).SetLoops(-1, LoopType.Restart);
    }
}
