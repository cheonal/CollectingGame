using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager gamemanager;
    [Header("�ӽ� ����")]
    public PlayerInform playerinform;
    public IdolInformation idolInformation;
    [Header("���̺�")]
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
    public int ActiveSlotNumber = 0; //���� ������ �ִ� ���� ��ȣ
    public int[,] IdolSlot = new int[10, 5]; //���� ������ �ִ� ���� ��ȣ, ĳ���� ��â ���� /���������� ������
    public int MainIdolNumber = 11; //�ǻ��, ������ ĳ���� ����â 
    [Header("�÷��̾�")]
    public string playerid;
    public string playername;

    public string storyplayername;
    public int idolgroupnumber;
    public int idolnumber;
    public int idollevel;

    public int freestar;
    public int paystar;

    [Header("2.Lobby")]
    public int playerlevel; //�κ�� �÷��̾� ���� ����
    public int playerexp; //�κ�� �÷��̾� ����ġ
    public int playermaxExp; //csv�� ��ϵ� �ִ����ġ
    public float playerexpScale; //�κ���� �Ѱ��� ������ ����
    public float energyexp; //�κ�� �ʷϻ� ������
    public float energyfilltime; //�κ�� �ʷϻ� Ÿ�̸�

    [Header("6.Quest")]
    public int passmaxExp; //csv�� ��ϵ� �н� �ִ����ġ
    public int passlevel; //����Ʈ ���� �Ѱ��� ���� �н� ����
    public int passexp; //����Ʈ ���� �Ѱ��� ���� �н� ����ġ
    public float passexpScale; //����Ʈ ���� �Ѱ��� �н� ������ ����
    public bool[] passItemList = new bool[70]; //�н� ������ ���� ���� ����Ʈ

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
    [Header("���̺� ����")]
    public float livewave;
    public float livehp;
    public float livelimittime;
    public float liveidol;
    public float liveskilllimit;
    public float liveskillcost;
}