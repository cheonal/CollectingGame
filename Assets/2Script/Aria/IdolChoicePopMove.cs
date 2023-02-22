using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IdolChoicePopMove : MonoBehaviour
{
    [SerializeField] RectTransform backbt;
    [SerializeField] RectTransform RightToLeft;
    [SerializeField] Image idolchara;

    // Start is called before the first frame update
    void Start()
    {
        backbt.DOAnchorPosX(30, 0.3f).SetAutoKill(false).SetLink(gameObject, LinkBehaviour.RestartOnEnable);
        RightToLeft.DOAnchorPosX(0, 0.3f).SetAutoKill(false).SetLink(gameObject, LinkBehaviour.RestartOnEnable);
        idolchara.DOFade(1, 0.3f).SetAutoKill(false).SetLink(gameObject, LinkBehaviour.RestartOnEnable);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
