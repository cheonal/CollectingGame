using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoopUpDown : MonoBehaviour
{
    //3�� Scene ����
    [SerializeField] RectTransform Cursor;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.DOAnchorPosY(50, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
