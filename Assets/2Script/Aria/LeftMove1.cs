using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LeftMove1 : MonoBehaviour
{
    //3�� Scene ����
    [SerializeField] RectTransform Uioff;
    [SerializeField] RectTransform Log;
    [SerializeField] RectTransform skip;
    [SerializeField] RectTransform storybtbg;

    // Start is called before the first frame update
    void Start()
    {
        //3�� Scene ����
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
