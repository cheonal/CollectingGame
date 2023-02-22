using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharaSetpop : MonoBehaviour
{
    public StageSet_11_5 stageSet_11_5;
    [SerializeField] GameObject CharaSetpopbg; //아이돌 편성창 눌렀을 시 나오는 아이돌 목록
    PlayerInform playerinform;
    int NowSecne; //현재 씬 위치 참고 변수
    /// <summary>
    /// 만약에 오류가 나면 게임 매니저를 상호작용 시마다 업데이트 해줘야 해결 가능할 듯!.
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
    /// <summary> CharaSetpopbg X버튼 </summary>
    public void CharaSetpopClose() 
    {
        CharaSetpopbg.SetActive(false);
    }
    /// <summary> CharaSetpopbg 에 Button 눌렀을 때,아이돌 아이콘 선택창에서 아이돌을 골랐을 때 </summary>
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
                //아이돌이 중복으로 선택될 경우 리스트에서 제거하고 배치하는 기능 
                for (int k = 0; k < 5; k++)
                {
                    if (playerinform.IdolSlot[playerinform.ActiveSlotNumber - 1, k] == idolnum)
                    {
                        playerinform.IdolSlot[playerinform.ActiveSlotNumber - 1, k] = 0;
                    }
                }
                //슬롯,편성칸에 있는 아이돌 슬롯에 아이돌 변수를 지정
                playerinform.IdolSlot[playerinform.ActiveSlotNumber - 1, stageSet_11_5.ListNum] = idolnum;
                stageSet_11_5.arrangement();
                break;
        }
    }
}
