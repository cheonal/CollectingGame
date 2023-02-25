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

    [SerializeField] Text PassLv; //�н� ����
    [SerializeField] Text PassExp; //�н� ����ġ
    [SerializeField] RectTransform PassScale; //�н� ����ġ ��
    int QuestPassLv; //�н� ������ �޾ƿ� ����
    int Questpassmaxexp; //�н� �ִ� ����ġ ���� �޾ƿ� ����
    float Questpassexp; //�н����� ��ġ�� �޾ƿ� ����
    float QuestpassExpScale; //�н����� ����ġ �������� �޾ƿ� ����

    [SerializeField] Button[] BasicItemList; // �⺻ �н� ��ư �迭
    [SerializeField] GameObject[] PassCheckList;//�н� ������ ���� Ȯ�� �迭 
    bool[] list = new bool[70]; // �н� ���� �迭

    // DailyMisson Csv ���� �Լ�
    List<Dictionary<string, object>> BasicItemdata;

    [SerializeField] Image passbt;
    [SerializeField] Image dailybt;
    [SerializeField] GameObject bg2Angle;
    [SerializeField] RectTransform passBanner;

    void Start()
    {
        if (gamemanager == null) // �� ��ȯ�� ���ӸŴ��� �Ҵ�
        {
            gamemanager = GameObject.Find("GameManager");
        }

        BasicItemdata = CSVReader.Read("DataPassLvReward");  // �н� ������ CSV ���� ��ġ

        passBanner.DOAnchorPosY(0, 1);
        passbt.color = new Color(48f / 255f, 140f / 255f, 166f / 255f);
    } 
    void Update()
    {
        PassEnable();
        PassState();
    }
    /// <summary> �н� ������ ���� ��ư Ȱ��ȭ </summary>
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
    /// ���� �Ŵ��� ����
    /// �÷��̾� �н� ����,����ġ,������ 
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

    /// <summary> ���� �н� �Ϲ� ���� ��ư Ŭ���� ȣ��Ǵ� �Լ� </summary>
    /// <param ��ame="nKey">���° ��ư����, �迭 Ȱ�� ������ 0������ ����</param>
    public void BasicItem(int nKey)
    {
        string[] itemReward = new string[BasicItemList.Length];
        for (int i = 0; i < BasicItemList.Length; i++)
        {
            itemReward[i] = (string)BasicItemdata[i]["PassBsReward"];
        }
        list[nKey] = true; //��ư Ȱ��ȭ �Լ�
        Debug.Log(itemReward[nKey]); //���� ���� �̺�Ʈ �Լ�
    }
    /// <summary> ���� �̼� ��ư Ŭ�� ��</summary>
    public void dailybtpress()
    {
        seasonpass.SetActive(false);
        dailymisson.SetActive(true);
        dailybt.color = new Color(159f / 255f, 55f / 255f, 107f / 255f);
        passbt.color = new Color(67f / 255f, 213f / 255f, 255f / 255f);
        bg2Angle.transform.DORotate(new Vector3(0, 0, -360), 0.2f, RotateMode.FastBeyond360);
    }
    /// <summary> ���� �н� ��ư Ŭ�� ��</summary>
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
