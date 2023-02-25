using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class ActiveMainIdol : MonoBehaviour
{
    [SerializeField] SkeletonGraphic MainIdol;
    public SkeletonDataAsset[] MainIdolNum;

    [SerializeField] GameObject CharaSetpopbg;

    public void Start()
    {
      /*  var skins = MainIdol.AnimationState.Data.SkeletonData.Skins.ToArray();
        MainIdol.skeletonDataAsset = MainIdolNum[Gamemanager.gamemanager.playerinform.MainIdolNumber];
        MainIdol.Skeleton.SetSkin(skins[1]);
        MainIdol.Initialize(true);*/
    }
    public void EtcCharabtn() //다른 캐릭터 버튼 클릭
    {
        CharaSetpopbg.SetActive(true);
    }
}
