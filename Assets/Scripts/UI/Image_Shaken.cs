using UnityEngine;
using DG.Tweening;

public class Image_Shaken : MonoBehaviour
{
    void Start()
    {
        transform.DOShakeRotation(1f, new Vector3(0, 0, 10), 4, 180, false).SetLoops(-1, LoopType.Incremental);
    }
}