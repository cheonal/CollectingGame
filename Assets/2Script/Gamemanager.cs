using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager gamemanager;
    [Header("임시 파일")]
    public PlayerInform playerinform;
    public IdolInformation idolInformation;
    [Header("라이브")]
    public liveInform liveInform;

    void Awake()
    {
        gamemanager = this;
        var obj = FindObjectsOfType<Gamemanager>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {

        for(int i = 0; i < 20; i++)
        {
            idolInformation.IdolList[i].idolId = i;
        }

    }

    public void Update()
    {
        LobbyPlayerState_2();
        LobbyTimer_2();
        QuestPass_6();
    }
    void LobbyPlayerState_2()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("DataPlayerLV");
        playerinform.playermaxExp = (int)data[playerinform.playerlevel -1]["playerEXP"];
        if (Input.GetKeyDown("a"))
        {
            playerinform.playerexp += 80;
        }
        if (playerinform.playerexp >= playerinform.playermaxExp)
        {
            playerinform.playerexp -= playerinform.playermaxExp;
            playerinform.playerlevel++;
        }
        playerinform.playerexpScale = (float)playerinform.playerexp / (float)playerinform.playermaxExp;
    }
    void LobbyTimer_2()
    {
        if (playerinform.energyexp < 10)
        {
            playerinform.energyfilltime -= 1 * Time.deltaTime;
        }
        if (playerinform.energyfilltime <= 0)
        {
            playerinform.energyexp++;
            playerinform.energyfilltime += 1800;
        }
    }
    void QuestPass_6()
    {
        List<Dictionary<string, object>> passdata = CSVReader.Read("DataPassLvReward");
        playerinform.passmaxExp = (int)passdata[playerinform.passlevel]["passAccEXP"];
        if (Input.GetKeyDown("q"))
        {
            playerinform.passexp += 100;
        }
        if (playerinform.passexp >= playerinform.passmaxExp)
        {
            playerinform.passexp -= playerinform.passmaxExp;
            playerinform.passlevel++;
        }
        playerinform.passexpScale = (float)playerinform.passexp / (float)playerinform.passmaxExp;
    }
    
}

[System.Serializable]
public class PlayerInform
{
    [Header("11_5 StageSet")]
    public int ActiveSlotNumber = 0; //현재 누르고 있는 슬롯 번호
    public int[,] IdolSlot = new int[10, 5]; //현재 누르고 있는 슬롯 번호, 캐릭터 편성창 순서 /수정끝나고 맨위로
    public int MainIdolNumber = 11; //의상실, 연습실 캐릭터 선택창 
    [Header("플레이어")]
    public string playerid;
    public string playername;

    public string storyplayername;
    public int idolgroupnumber;
    public int idolnumber;
    public int idollevel;

    public int freestar;
    public int paystar;

    [Header("2.Lobby")]
    public int playerlevel; //로비씬 플레이어 현재 레벨
    public int playerexp; //로비씬 플레이어 경험치
    public int playermaxExp; //csv에 등록된 최대경험치
    public float playerexpScale; //로비씬에 넘겨줄 스케일 변수
    public float energyexp; //로비씬 초록색 게이지
    public float energyfilltime; //로비씬 초록색 타이머

    [Header("6.Quest")]
    public int passmaxExp; //csv에 등록된 패스 최대경험치
    public int passlevel; //퀘스트 씬에 넘겨줄 현재 패스 레벨
    public int passexp; //퀘스트 씬에 넘겨줄 현재 패스 경험치
    public float passexpScale; //퀘스트 씬에 넘겨줄 패스 스케일 변수
    public bool[] passItemList = new bool[70]; //패스 아이템 수령 관리 리스트

    public float statusvo;
    public float statusvoexp;
    public float statusda;
    public float statusdaexp;
    public float statuspf;
    public float statuspfexp;
    public float statusidol;
    public float statusidolexp;

    public float itemgrade;
    public int itemlevel;
    public float itemunlimit;

    public int stagenumber;
    public int daynumber;
    public float draw;
}
[System.Serializable]
public class IdolInformation
{
    public Idol[] IdolList = new Idol[20];
}
[System.Serializable]
public class Idol
{
    public int idolId =0;
    public int dressId =0;
    public int ItemId =0;
}
[System.Serializable]
public class liveInform
{
    [Header("라이브 정보")]
    public float livewave;
    public float livehp;
    public float livelimittime;
    public float liveidol;
    public float liveskilllimit;
    public float liveskillcost;
}