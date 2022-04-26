using UnityEngine;
using DG.Tweening;

public class Image_Shaken_Move : MonoBehaviour
{
    void Start()
    {
        transform.DOMoveY(150f, 0.75f, false).SetLoops(-1, LoopType.Yoyo);
        transform.DOMoveX(4000f, 10f, false).SetLoops(-1, LoopType.Restart);
    }
}
