using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PracticeTw : MonoBehaviour
{
    //8¹ø Scene Àû¿ë
    [SerializeField] RectTransform Main;
    [SerializeField] RectTransform IdolLVUP;
    [SerializeField] RectTransform Profile;
    [SerializeField] RectTransform Episode;
    [SerializeField] RectTransform UpPop;
    [SerializeField] GameObject UpPopObj;

    // Start is called before the first frame update
    void Start()
    {
        GameObject MainObj = transform.Find("Main").gameObject;
        Main.DOAnchorPosX(0, 0.3f).SetAutoKill(false).SetLink(MainObj, LinkBehaviour.RestartOnEnable);

        GameObject IdolLVUPObj = transform.Find("IdolLVUP").gameObject;
        IdolLVUP.DOAnchorPosX(0, 0.3f).SetAutoKill(false).SetLink(IdolLVUPObj, LinkBehaviour.RestartOnEnable);

        GameObject ProfileObj = transform.Find("Profile").gameObject;
        Profile.DOAnchorPosX(400, 0.3f).SetAutoKill(false).SetLink(ProfileObj, LinkBehaviour.RestartOnEnable);

        GameObject EpisodeObj = transform.Find("Episode").gameObject;
        Episode.DOAnchorPosX(0, 0.3f).SetAutoKill(false).SetLink(EpisodeObj, LinkBehaviour.RestartOnEnable);

        UpPop.DOScale(new Vector3(1f, 1f, 1f), 0.5f).SetAutoKill(false).SetLink(UpPopObj, LinkBehaviour.RestartOnEnable);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
