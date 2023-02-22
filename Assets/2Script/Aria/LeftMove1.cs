using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LeftMove1 : MonoBehaviour
{
    //3번 Scene 적용
    [SerializeField] RectTransform Uioff;
    [SerializeField] RectTransform Log;
    [SerializeField] RectTransform skip;
    [SerializeField] RectTransform storybtbg;

    // Start is called before the first frame update
    void Start()
    {
        //3번 Scene 적용
        Uioff.DOAnchorPosX(-140, 0.3f).SetAutoKill(false).SetLink(gameObject, LinkBehaviour.RestartOnEnable);
        Log.DOAnchorPosX(-280, 0.3f).SetAutoKill(false).SetLink(gameObject, LinkBehaviour.RestartOnEnable);
        skip.DOAnchorPosX(-420, 0.3f).SetAutoKill(false).SetLink(gameObject, LinkBehaviour.RestartOnEnable);
        storybtbg.DOScaleX(1, 0.3f).SetAutoKill(false).SetLink(gameObject, LinkBehaviour.RestartOnEnable);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
