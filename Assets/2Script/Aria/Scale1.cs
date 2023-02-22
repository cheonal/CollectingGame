using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scale1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //1¹ø Scene Àû¿ë
        RectTransform mn = GetComponent<RectTransform>();
        mn.DOScale(new Vector3(1f, 1f, 1f), 0.5f).SetAutoKill(false).SetLink(gameObject, LinkBehaviour.RestartOnEnable);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
