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

   /* public void EtcCharabtn() //�ٸ� ĳ���� ��ư Ŭ��
    {
        CharaSetpopbg.SetActive(true);
    }*/

    public void IdolLvUpbtn() //����� ������ ��ư Ŭ��
    {
        btnnumber++;
        Main.SetActive(false);
        IdolLVUP.SetActive(true);
    }

    public void Profilebtn() //������ ��ư Ŭ��
    {
        btnnumber++;
        Main.SetActive(false);
        Profile.SetActive(true);
    }
    public void Episodebtn() //���̵� ���Ǽҵ� ��ư Ŭ��
    {
        btnnumber++;
        Main.SetActive(false);
        Episode.SetActive(true);
    }
    public void SPEpisodebtn() //����� ���Ǽҵ� ��ư Ŭ��
    {
        btnnumber++;
        Main.SetActive(false);
        Episode.SetActive(true);
    }

    public void SkUpPopClose()//���̵� ������ �˾� ��Ȱ��ȭ
    {
        UpPop.SetActive(false);
    }
    public void VoLVUPbtn() //���� ������ ��ư Ŭ���ؼ� �˾� Ȱ��ȭ
    {
        UpPop.SetActive(true);
    }
    public void DaLVUPbtn() //�� ������ ��ư Ŭ���ؼ� �˾� Ȱ��ȭ
    {
        UpPop.SetActive(true);
    }
    public void PfLVUPbtn() //�����ս� ������ ��ư Ŭ���ؼ� �˾� Ȱ��ȭ
    {
        UpPop.SetActive(true);
    }
    public void IdolSkLVUPbtn() //���̵���ų ������ ��ư Ŭ���ؼ� �˾� Ȱ��ȭ
    {
        UpPop.SetActive(true);
    }
}
