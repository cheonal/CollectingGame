using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //가이드 적용 Image Type
        Image img = GetComponent<Image>();
        img.DOFade(0, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InQuad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
