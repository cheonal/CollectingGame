using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice_8 : MonoBehaviour
{



    [SerializeField] GameObject Main;
    [SerializeField] GameObject CharaSetpopbg;
    [SerializeField] GameObject IdolLVUP;
    [SerializeField] GameObject Profile;
    [SerializeField] GameObject Episode;
    [SerializeField] GameObject UpPop;

    int btnnumber = 1;

    public void BackBtn()
    {
        btnnumber -= 1;

        if (btnnumber == 0)
        {
            Loading.Instance.ChangeScene("2.Lobby");
        }
        if (btnnumber == 1)
        {
            Main.SetActive(true);
            IdolLVUP.SetActive(false);
            Profile.SetActive(false);
            Episode.SetActive(false);
        }
    }

   /* public void EtcCharabtn() //다른 캐릭터 버튼 클릭
    {
        CharaSetpopbg.SetActive(true);
    }*/

    public void IdolLvUpbtn() //보라색 레벨업 버튼 클릭
    {
        btnnumber++;
        Main.SetActive(false);
        IdolLVUP.SetActive(true);
    }

    public void Profilebtn() //프로필 버튼 클릭
    {
        btnnumber++;
        Main.SetActive(false);
        Profile.SetActive(true);
    }
    public void Episodebtn() //아이돌 에피소드 버튼 클릭
    {
        btnnumber++;
        Main.SetActive(false);
        Episode.SetActive(true);
    }
    public void SPEpisodebtn() //스페셜 에피소드 버튼 클릭
    {
        btnnumber++;
        Main.SetActive(false);
        Episode.SetActive(true);
    }

    public void SkUpPopClose()//아이돌 레벨업 팝업 비활성화
    {
        UpPop.SetActive(false);
    }
    public void VoLVUPbtn() //보컬 레벨업 버튼 클릭해서 팝업 활성화
    {
        UpPop.SetActive(true);
    }
    public void DaLVUPbtn() //댄스 레벨업 버튼 클릭해서 팝업 활성화
    {
        UpPop.SetActive(true);
    }
    public void PfLVUPbtn() //퍼포먼스 레벨업 버튼 클릭해서 팝업 활성화
    {
        UpPop.SetActive(true);
    }
    public void IdolSkLVUPbtn() //아이돌스킬 레벨업 버튼 클릭해서 팝업 활성화
    {
        UpPop.SetActive(true);
    }
}
