using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadEffec : MonoBehaviour
{
    [SerializeField] RectTransform StarFlower;

    // Start is called before the first frame update
    void Start()
    {
        StarFlower.DOAnchorPos(new Vector2(-3840, 2160), 50f).SetLoops(-1, LoopType.Restart).SetAutoKill(false).SetLink(gameObject, LinkBehaviour.RestartOnEnable);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
