using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Quest_6 : MonoBehaviour
{
    public GameObject gamemanager;
    [SerializeField] GameObject dailymisson; 
    [SerializeField] GameObject seasonpass;

    [SerializeField] Text PassLv; //패스 레벨
    [SerializeField] Text PassExp; //패스 경험치
    [SerializeField] RectTransform PassScale; //패스 경험치 바
    int QuestPassLv; //패스 레벨을 받아올 변수
    int Questpassmaxexp; //패스 최대 경험치 값을 받아올 변수
    float Questpassexp; //패스바의 수치를 받아올 변수
    float QuestpassExpScale; //패스바의 경험치 스케일을 받아올 변수

    [SerializeField] Button[] BasicItemList; // 기본 패스 버튼 배열
    [SerializeField] GameObject[] PassCheckList;//패스 아이템 수령 확인 배열 
    bool[] list = new bool[70]; // 패스 보상 배열

    // DailyMisson Csv 관리 함수
    List<Dictionary<string, object>> BasicItemdata;

    [SerializeField] Image passbt;
    [SerializeField] Image dailybt;
    [SerializeField] GameObject bg2Angle;
    [SerializeField] RectTransform passBanner;

    void Start()
    {
        if (gamemanager == null) // 씬 전환시 게임매니저 할당
        {
            gamemanager = GameObject.Find("GameManager");
        }

        BasicItemdata = CSVReader.Read("DataPassLvReward");  // 패스 아이템 CSV 파일 배치

        passBanner.DOAnchorPosY(0, 1);
        passbt.color = new Color(48f / 255f, 140f / 255f, 166f / 255f);
    } 
    void Update()
    {
        PassEnable();
        PassState();
    }
    /// <summary> 패스 레벨에 따른 버튼 활성화 </summary>
    void PassEnable()
    {
        list = Gamemanager.gamemanager.playerinform.passItemList;
        for (int i = 0; i < QuestPassLv; i++)
        {
            BasicItemList[i].interactable = true;
        }
        for (int v = 0; v < BasicItemList.Length; v++)
        {
            if (list[v])
            {
                PassCheckList[v].SetActive(true);
                BasicItemList[v].interactable = false;
            }
        }

    }
    /// <summary>
    /// 게임 매니저 참조
    /// 플레이어 패스 레벨,경험치,스케일 
    /// </summary>
    void PassState()
    {
        QuestpassExpScale = gamemanager.GetComponent<Gamemanager>().playerinform.passexpScale;
        QuestPassLv = gamemanager.GetComponent<Gamemanager>().playerinform.passlevel;
        Questpassexp = gamemanager.GetComponent<Gamemanager>().playerinform.passexp;
        Questpassmaxexp = gamemanager.GetComponent<Gamemanager>().playerinform.passmaxExp;

        PassLv.text = QuestPassLv.ToString();
        PassScale.localScale = new Vector2(QuestpassExpScale, 1);
        PassExp.text = Questpassexp.ToString() + "/" + Questpassmaxexp.ToString();
    }

    /// <summary> 시즌 패스 일반 보상 버튼 클릭시 호출되는 함수 </summary>
    /// <param ㅋame="nKey">몇번째 버튼인지, 배열 활용 때문에 0번부터 시작</param>
    public void BasicItem(int nKey)
    {
        string[] itemReward = new string[BasicItemList.Length];
        for (int i = 0; i < BasicItemList.Length; i++)
        {
            itemReward[i] = (string)BasicItemdata[i]["PassBsReward"];
        }
        list[nKey] = true; //버튼 활성화 함수
        Debug.Log(itemReward[nKey]); //보상 수령 이벤트 함수
    }
    /// <summary> 일일 미션 버튼 클릭 시</summary>
    public void dailybtpress()
    {
        seasonpass.SetActive(false);
        dailymisson.SetActive(true);
        dailybt.color = new Color(159f / 255f, 55f / 255f, 107f / 255f);
        passbt.color = new Color(67f / 255f, 213f / 255f, 255f / 255f);
        bg2Angle.transform.DORotate(new Vector3(0, 0, -360), 0.2f, RotateMode.FastBeyond360);
    }
    /// <summary> 시즌 패스 버튼 클릭 시</summary>
    public void passbtpress()
    {
        seasonpass.SetActive(true);
        dailymisson.SetActive(false);
        passbt.color = new Color(48f / 255f, 140f / 255f, 166f / 255f);
        dailybt.color = new Color(248f / 255f, 121f / 255f, 184f / 255f);
        bg2Angle.transform.DORotate(new Vector3(0, 0, -360), 0.2f, RotateMode.FastBeyond360);
    }
    public void BackBtn()
    {
        Loading.Instance.ChangeScene("2.Lobby");
        //SceneManager.LoadScene("2.Lobby");
    }


}
