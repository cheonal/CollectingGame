using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LeftMove2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RectTransform Storyselec = GetComponent<RectTransform>();
        Storyselec.DOAnchorPosX(-100, 0.3f).SetAutoKill(false).SetLink(gameObject, LinkBehaviour.RestartOnEnable);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
