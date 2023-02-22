using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BackEffec : MonoBehaviour
{
    //임시 배경용 애니메이션
    [SerializeField] RectTransform BackLogo;

    // Start is called before the first frame update
    void Start()
    {
        BackLogo.DOAnchorPos(new Vector2(-1800, 960), 50f).SetLoops(-1, LoopType.Yoyo).SetAutoKill(false).SetLink(gameObject, LinkBehaviour.RestartOnEnable);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
