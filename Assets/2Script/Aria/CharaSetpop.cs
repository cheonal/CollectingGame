using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharaSetpop : MonoBehaviour
{
    public StageSet_11_5 stageSet_11_5;
    [SerializeField] GameObject CharaSetpopbg; //���̵� ��â ������ �� ������ ���̵� ���
    PlayerInform playerinform;
    int NowSecne; //���� �� ��ġ ���� ����
    /// <summary>
    /// ���࿡ ������ ���� ���� �Ŵ����� ��ȣ�ۿ� �ø��� ������Ʈ ����� �ذ� ������ ��!.
    /// </summary>
    void Start()
    {
        playerinform = Gamemanager.gamemanager.playerinform;
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "8.Practice")
        {
            NowSecne = 1;
        }
        else if (SceneManager.GetActiveScene().name == "9.DressRoom")
        {
            NowSecne = 2;
        }
        else if (SceneManager.GetActiveScene().name == "2.Lobby")
        {
            NowSecne = 3;
        }
        else if (SceneManager.GetActiveScene().name == "11_5.StageSet")
        {
            NowSecne = 4;
        }
    }
    /// <summary> CharaSetpopbg X��ư </summary>
    public void CharaSetpopClose() 
    {
        CharaSetpopbg.SetActive(false);
    }
    /// <summary> CharaSetpopbg �� Button ������ ��,���̵� ������ ����â���� ���̵��� ����� �� </summary>
    public void IdolSet(int idolnum)
    {
        Debug.Log(idolnum);

        switch (NowSecne)
        {
            case 1:
            case 2:
            case 3:
                Gamemanager.gamemanager.playerinform.MainIdolNumber = idolnum;
                ActiveMainIdol activeMainIdol = GameObject.Find("ActiveMainIdolManager").GetComponent<ActiveMainIdol>();
                activeMainIdol.Start();
                break;

            case 4:
                //���̵��� �ߺ����� ���õ� ��� ����Ʈ���� �����ϰ� ��ġ�ϴ� ��� 
                for (int k = 0; k < 5; k++)
                {
                    if (playerinform.IdolSlot[playerinform.ActiveSlotNumber - 1, k] == idolnum)
                    {
                        playerinform.IdolSlot[playerinform.ActiveSlotNumber - 1, k] = 0;
                    }
                }
                //����,��ĭ�� �ִ� ���̵� ���Կ� ���̵� ������ ����
                playerinform.IdolSlot[playerinform.ActiveSlotNumber - 1, stageSet_11_5.ListNum] = idolnum;
                stageSet_11_5.arrangement();
                break;
        }
    }
}
