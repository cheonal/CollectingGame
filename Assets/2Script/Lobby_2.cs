using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Lobby_2 : MonoBehaviour
{
    public GameObject gamemanager;
    [SerializeField] GameObject IdolsLine; //아이돌 클릭시 대사
    [SerializeField] Text PlayerLv; //플레이어 레벨
    [SerializeField] RectTransform PlayerExp; //플레이어 경험치 바
    int LobbyPlayerLv; //플레이어 레벨을 받아올 변수
    float LobbyPlayerExpScale; //플레이어 경험치 스케일을 받아올 변수

    void Start()
    {
        if (gamemanager == null) //씬 전환시 게임매니저 할당
        {
            gamemanager = GameObject.Find("GameManager");
        }
    }

    void Update()
    {
        Csvtt();
    }
    void Csvtt() //플레이어 레벨,경험치를 관리하는 함수
    {
        LobbyPlayerExpScale = gamemanager.GetComponent<Gamemanager>().playerinform.playerexpScale;
        LobbyPlayerLv = gamemanager.GetComponent<Gamemanager>().playerinform.playerlevel;

        PlayerLv.text = LobbyPlayerLv.ToString();
        PlayerExp.localScale = new Vector2(LobbyPlayerExpScale, 1);
    }

    public void IdolsLineOn() //대사 출력후 3초뒤 자동 비활성화
    {
        IdolsLine.SetActive(true);
        Invoke("IdolsLineOut", 3f);
    }
    void IdolsLineOut() // 애니메이션 효과로 대화창을 끌지 의논필요
    {
        IdolsLine.SetActive(false);
    }
    /// <summary>
    /// //////////////버튼 그룹
    /// </summary>
    public void Quest()
    {
        Loading.Instance.ChangeScene("6.Quest");
    }
    public void Story()
    {
        Loading.Instance.ChangeScene("7.StoryMenu");
    }
    public void EventBanner() => Debug.Log("이벤트 배너 오픈"); // 진행중 이벤트 화면 오픈
    public void Dress()
    {
        Loading.Instance.ChangeScene("9.DressRoom");
    }

    public void Shop()
    {
        Loading.Instance.ChangeScene("10.Shopping");
    }

    public void Optione() => Debug.Log("메뉴 오픈"); // 환경 설정,소지품 확인 등 편의 기능 메뉴

    public void Practice()
    {
        Loading.Instance.ChangeScene("8.Practice");
    }

    public void IdolsActive() //라이브 화면 진입
    {
        Loading.Instance.ChangeScene("11.Stage");
    }

    public void ActivePlus() => Debug.Log("활동게이지 충전"); //활동게이지 충
    public void StarPlus() => Debug.Log("별 충전"); //별 충전

}
