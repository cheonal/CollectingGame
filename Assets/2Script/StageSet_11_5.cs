using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSet_11_5 : MonoBehaviour
{
    public int RoomNum; //현재 캐릭터,의상,액세서리 탭 확인 변수
    public int ListNum; //현재 클릭한 아이돌의 슬롯 위치 확인 변수
    PlayerInform playerinform;
    IdolInformation idolinform;

    [Header("-슬롯,아이돌 버튼 관리-")]
    [SerializeField] Image[] SlotBtnList; //눌리기전 1 버튼 이미지
    [SerializeField] Sprite ClasicSlotBtn;//눌리기전 슬롯 버튼 이미지 스프라이트
    [SerializeField] Sprite PressSlotBtn; //눌린후 바뀌는 슬롯 버튼 이미지 스프라이트
    [SerializeField] Sprite[] IdolSprite; //아이돌 이미지 모음
    [SerializeField] Sprite[] dressSprite; //아이돌 의상 이미지
    [SerializeField] GameObject[] ItemSetPos; //아이돌 편성창 하단 아이템 모음
    [SerializeField] GameObject[] Charbg;  //아이돌 편성창 하단 능력치 모음
    [SerializeField] GameObject Setpopbg; //아이돌 편성창 하단 박스 눌렀을 시 나오는 의상 아이템 목록
    [SerializeField] GameObject CharaSetpopbg; //아이돌 편성창 눌렀을 시 나오는 아이돌 목록
    [SerializeField] Image[] idolSet; //아이돌 네모 이미지
    [SerializeField] Image[] dressSet; //아이돌 의상 이미지

    [Header("-단순 버튼 관리-")]
    [SerializeField] GameObject LeftArrow; //좌측 화살표
    [SerializeField] GameObject RightArrow; //우측 화살표
    [SerializeField] Image CharBtn; //초록색 캐릭터 버튼
    [SerializeField] Image DressBtn; //파랑색 의상 버튼
    [SerializeField] Image AccBtn; //분홍색 액세서리 버튼

    [Header ("-색깔 관리-")]
    [SerializeField] Color ClasicCharBtnColor;
    [SerializeField] Color PressCharBtnColor;
    [SerializeField] Color ClasicDressBtnColor;
    [SerializeField] Color PressDressBtnColor;
    [SerializeField] Color ClasicAccBtnColor;
    [SerializeField] Color PressAccBtnColor;
    void Start()
    {
        playerinform = Gamemanager.gamemanager.playerinform;
        idolinform = Gamemanager.gamemanager.idolInformation;
        //11.5씬에 진입할 때 게임매니저에 1번 슬롯 눌러지도록 할당
        if (Gamemanager.gamemanager.playerinform.ActiveSlotNumber == 0) 
        {
            Gamemanager.gamemanager.playerinform.ActiveSlotNumber = 1;
        }
        Slot1Active(Gamemanager.gamemanager.playerinform.ActiveSlotNumber - 1);
        arrangement();
    }
    /// <summary> 이미지 배치하는 코드, 업데이트문 사용 안할 시 상호작용 할 때마다 호출되어야 함 </summary>
    public void arrangement()
    {
        for (int i = 0; i < 5; i++)
        {
            //편성창 5칸에 아이돌 이미지 /슬롯 편성창에있는 아이돌 변수로 스프라이트 설정
            idolSet[i].sprite = IdolSprite[playerinform.IdolSlot[playerinform.ActiveSlotNumber-1, i]];
            //편성창 5칸에 드레스 이미지 /슬롯 편성창에있는 아이돌의 드레스 아이디로 스프라이트 설정
            dressSet[i].sprite = dressSprite[idolinform.IdolList[playerinform.IdolSlot[playerinform.ActiveSlotNumber - 1, i]].dressId];

            //현재 캐릭터칸인지 드레스룸인지에 따라서 이미지 변경
            switch (RoomNum)
            {
                case 1:
                    ItemSetPos[i].SetActive(false);
                    if (playerinform.IdolSlot[playerinform.ActiveSlotNumber - 1, i] == 0)
                    {
                        //아이돌 능력치 창
                        Charbg[i].SetActive(false);
                    }
                    else
                    {
                        Charbg[i].SetActive(true);
                    }
                    break;
                case 2:
                        Charbg[i].SetActive(false);
                    if (playerinform.IdolSlot[playerinform.ActiveSlotNumber - 1, i] == 0)
                    {
                        //아이돌 장비 창
                        ItemSetPos[i].SetActive(false);
                    }
                    else
                    {
                        ItemSetPos[i].SetActive(true);
                    }
                    break;
            }
        }
    }
    public void BackBtn()
    {
        Loading2.Instance.ChangeScene("11.Stage");
    }
    /// <summary> 아이돌 편성창 1~5 눌렀을때 </summary>
    public void IdolSetActive(int key)
    {
        if (RoomNum != 1)
            return;
        Debug.Log("IdolSetActive");
        CharaSetpopbg.SetActive(true);
        ListNum = key - 1;
    }
    /// <summary> 아이돌 편성창 밑 장비 1~5 눌렀을때 </summary>
    public void DressSetActive(int key)
    {
        Debug.Log("DressSetActive");
        Setpopbg.SetActive(true);
        ListNum = key - 1;
    }
    /// <summary> setpopbg 에 Button 눌렀을 때,의상 선택창에서 의상을 골랐을 때 </summary>
    public void DressSet(int dressnum)
    {
        Debug.Log("DressSet");
        //슬롯, 편성칸에 있는 아이돌의 변수를 확인하고 아이돌의 드레스 변수를 지정
        idolinform.IdolList[playerinform.IdolSlot[playerinform.ActiveSlotNumber - 1, ListNum]].dressId = dressnum;
        arrangement();
        SetpopbgBackBtn();
    }
    public void SetpopbgBackBtn() //Setpopbg X버튼
    {
        Setpopbg.SetActive(false);
    }
    /// <summary> "캐릭터" 버튼 눌렀을 때 </summary>
    public void CharBtnClick()
    {
        RoomNum = 1;
        CharBtn.color = PressCharBtnColor;
        DressBtn.color = ClasicDressBtnColor;
        AccBtn.color = ClasicAccBtnColor;
        arrangement();
    }
    /// <summary>"의상" 버튼 눌렀을 때 </summary>
    public void DressBtnClick()
    {
        RoomNum = 2;
        CharBtn.color = ClasicCharBtnColor;
        DressBtn.color = PressDressBtnColor;
        AccBtn.color = ClasicAccBtnColor;
        arrangement();
    }
    /// <summary> "액새서리" 버튼 눌렀을 때 </summary>
    public void AccBtnClick()
    {
        RoomNum = 3;
        CharBtn.color = ClasicCharBtnColor;
        DressBtn.color = ClasicDressBtnColor;
        AccBtn.color = PressAccBtnColor;
        arrangement();
    }
    /// <summary> 슬롯 1~10번째 눌렀을때 작동하는 함수 </summary>
    /// <param name="nKey">슬롯 번호</param>
    public void Slot1Active(int nKey)
    {
        CharBtnClick(); //캐릭터 버튼 활성화
        #region 슬롯 설정 함수
        for (int i = 0; i < 10; i++) //모든 슬롯 안눌린 상태로 초기화
        {
            SlotBtnList[i].sprite = ClasicSlotBtn;
        }
        if (nKey == 0) //1번째 슬롯 활성화
        {
            SlotBtnList[nKey].sprite = PressSlotBtn;
            playerinform.ActiveSlotNumber = 1;
            LeftArrow.SetActive(false);
        }
        else if (nKey > 0 && nKey < 9) //2~9번째 슬롯 활성화 11
        {
            SlotBtnList[nKey].sprite = PressSlotBtn;
            playerinform.ActiveSlotNumber = nKey + 1;
            LeftArrow.SetActive(true);
            RightArrow.SetActive(true);
        }
        else if (nKey == 9) //10번째 슬롯 활성화
        {
            SlotBtnList[nKey].sprite = PressSlotBtn;
            playerinform.ActiveSlotNumber = 10;
            LeftArrow.SetActive(true);
            RightArrow.SetActive(false);
        }
        #endregion
        arrangement();
    }

    public void LiveStartBt() //공연 시작 버튼 눌렀을때
    {
        Loading.Instance.ChangeScene("12.Live");
    }
}
