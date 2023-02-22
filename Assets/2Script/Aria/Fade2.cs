using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //가이드 적용 Text Type
        Text txt = GetComponent<Text>();
        txt.DOFade(0, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InQuad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
