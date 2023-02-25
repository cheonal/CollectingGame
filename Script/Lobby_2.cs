using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Lobby_2 : MonoBehaviour
{
    public GameObject gamemanager;
    [SerializeField] GameObject IdolsLine; //���̵� Ŭ���� ���
    [SerializeField] Text PlayerLv; //�÷��̾� ����
    [SerializeField] RectTransform PlayerExp; //�÷��̾� ����ġ ��
    int LobbyPlayerLv; //�÷��̾� ������ �޾ƿ� ����
    float LobbyPlayerExpScale; //�÷��̾� ����ġ �������� �޾ƿ� ����

    void Start()
    {
        if (gamemanager == null) //�� ��ȯ�� ���ӸŴ��� �Ҵ�
        {
            gamemanager = GameObject.Find("GameManager");
        }
    }

    void Update()
    {
        Csvtt();
    }
    void Csvtt() //�÷��̾� ����,����ġ�� �����ϴ� �Լ�
    {
        LobbyPlayerExpScale = gamemanager.GetComponent<Gamemanager>().playerinform.playerexpScale;
        LobbyPlayerLv = gamemanager.GetComponent<Gamemanager>().playerinform.playerlevel;

        PlayerLv.text = LobbyPlayerLv.ToString();
        PlayerExp.localScale = new Vector2(LobbyPlayerExpScale, 1);
    }

    public void IdolsLineOn() //��� ����� 3�ʵ� �ڵ� ��Ȱ��ȭ
    {
        IdolsLine.SetActive(true);
        Invoke("IdolsLineOut", 3f);
    }
    void IdolsLineOut() // �ִϸ��̼� ȿ���� ��ȭâ�� ���� �ǳ��ʿ�
    {
        IdolsLine.SetActive(false);
    }
    /// <summary>
    /// //////////////��ư �׷�
    /// </summary>
    public void Quest()
    {
        Loading.Instance.ChangeScene("6.Quest");
    }
    public void Story()
    {
        Loading.Instance.ChangeScene("7.StoryMenu");
    }
    public void EventBanner() => Debug.Log("�̺�Ʈ ��� ����"); // ������ �̺�Ʈ ȭ�� ����
    public void Dress()
    {
        Loading.Instance.ChangeScene("9.DressRoom");
    }

    public void Shop()
    {
        Loading.Instance.ChangeScene("10.Shopping");
    }

    public void Optione() => Debug.Log("�޴� ����"); // ȯ�� ����,����ǰ Ȯ�� �� ���� ��� �޴�

    public void Practice()
    {
        Loading.Instance.ChangeScene("8.Practice");
    }

    public void IdolsActive() //���̺� ȭ�� ����
    {
        Loading.Instance.ChangeScene("11.Stage");
    }

    public void ActivePlus() => Debug.Log("Ȱ�������� ����"); //Ȱ�������� ��
    public void StarPlus() => Debug.Log("�� ����"); //�� ����

}
