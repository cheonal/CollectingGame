using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSet_11_5 : MonoBehaviour
{
    public int RoomNum; //���� ĳ����,�ǻ�,�׼����� �� Ȯ�� ����
    public int ListNum; //���� Ŭ���� ���̵��� ���� ��ġ Ȯ�� ����
    PlayerInform playerinform;
    IdolInformation idolinform;

    [Header("-����,���̵� ��ư ����-")]
    [SerializeField] Image[] SlotBtnList; //�������� 1 ��ư �̹���
    [SerializeField] Sprite ClasicSlotBtn;//�������� ���� ��ư �̹��� ��������Ʈ
    [SerializeField] Sprite PressSlotBtn; //������ �ٲ�� ���� ��ư �̹��� ��������Ʈ
    [SerializeField] Sprite[] IdolSprite; //���̵� �̹��� ����
    [SerializeField] Sprite[] dressSprite; //���̵� �ǻ� �̹���
    [SerializeField] GameObject[] ItemSetPos; //���̵� ��â �ϴ� ������ ����
    [SerializeField] GameObject[] Charbg;  //���̵� ��â �ϴ� �ɷ�ġ ����
    [SerializeField] GameObject Setpopbg; //���̵� ��â �ϴ� �ڽ� ������ �� ������ �ǻ� ������ ���
    [SerializeField] GameObject CharaSetpopbg; //���̵� ��â ������ �� ������ ���̵� ���
    [SerializeField] Image[] idolSet; //���̵� �׸� �̹���
    [SerializeField] Image[] dressSet; //���̵� �ǻ� �̹���

    [Header("-�ܼ� ��ư ����-")]
    [SerializeField] GameObject LeftArrow; //���� ȭ��ǥ
    [SerializeField] GameObject RightArrow; //���� ȭ��ǥ
    [SerializeField] Image CharBtn; //�ʷϻ� ĳ���� ��ư
    [SerializeField] Image DressBtn; //�Ķ��� �ǻ� ��ư
    [SerializeField] Image AccBtn; //��ȫ�� �׼����� ��ư

    [Header ("-���� ����-")]
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
        //11.5���� ������ �� ���ӸŴ����� 1�� ���� ���������� �Ҵ�
        if (Gamemanager.gamemanager.playerinform.ActiveSlotNumber == 0) 
        {
            Gamemanager.gamemanager.playerinform.ActiveSlotNumber = 1;
        }
        Slot1Active(Gamemanager.gamemanager.playerinform.ActiveSlotNumber - 1);
        arrangement();
    }
    /// <summary> �̹��� ��ġ�ϴ� �ڵ�, ������Ʈ�� ��� ���� �� ��ȣ�ۿ� �� ������ ȣ��Ǿ�� �� </summary>
    public void arrangement()
    {
        for (int i = 0; i < 5; i++)
        {
            //��â 5ĭ�� ���̵� �̹��� /���� ��â���ִ� ���̵� ������ ��������Ʈ ����
            idolSet[i].sprite = IdolSprite[playerinform.IdolSlot[playerinform.ActiveSlotNumber-1, i]];
            //��â 5ĭ�� �巹�� �̹��� /���� ��â���ִ� ���̵��� �巹�� ���̵�� ��������Ʈ ����
            dressSet[i].sprite = dressSprite[idolinform.IdolList[playerinform.IdolSlot[playerinform.ActiveSlotNumber - 1, i]].dressId];

            //���� ĳ����ĭ���� �巹���������� ���� �̹��� ����
            switch (RoomNum)
            {
                case 1:
                    ItemSetPos[i].SetActive(false);
                    if (playerinform.IdolSlot[playerinform.ActiveSlotNumber - 1, i] == 0)
                    {
                        //���̵� �ɷ�ġ â
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
                        //���̵� ��� â
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
    /// <summary> ���̵� ��â 1~5 �������� </summary>
    public void IdolSetActive(int key)
    {
        if (RoomNum != 1)
            return;
        Debug.Log("IdolSetActive");
        CharaSetpopbg.SetActive(true);
        ListNum = key - 1;
    }
    /// <summary> ���̵� ��â �� ��� 1~5 �������� </summary>
    public void DressSetActive(int key)
    {
        Debug.Log("DressSetActive");
        Setpopbg.SetActive(true);
        ListNum = key - 1;
    }
    /// <summary> setpopbg �� Button ������ ��,�ǻ� ����â���� �ǻ��� ����� �� </summary>
    public void DressSet(int dressnum)
    {
        Debug.Log("DressSet");
        //����, ��ĭ�� �ִ� ���̵��� ������ Ȯ���ϰ� ���̵��� �巹�� ������ ����
        idolinform.IdolList[playerinform.IdolSlot[playerinform.ActiveSlotNumber - 1, ListNum]].dressId = dressnum;
        arrangement();
        SetpopbgBackBtn();
    }
    public void SetpopbgBackBtn() //Setpopbg X��ư
    {
        Setpopbg.SetActive(false);
    }
    /// <summary> "ĳ����" ��ư ������ �� </summary>
    public void CharBtnClick()
    {
        RoomNum = 1;
        CharBtn.color = PressCharBtnColor;
        DressBtn.color = ClasicDressBtnColor;
        AccBtn.color = ClasicAccBtnColor;
        arrangement();
    }
    /// <summary>"�ǻ�" ��ư ������ �� </summary>
    public void DressBtnClick()
    {
        RoomNum = 2;
        CharBtn.color = ClasicCharBtnColor;
        DressBtn.color = PressDressBtnColor;
        AccBtn.color = ClasicAccBtnColor;
        arrangement();
    }
    /// <summary> "�׻�����" ��ư ������ �� </summary>
    public void AccBtnClick()
    {
        RoomNum = 3;
        CharBtn.color = ClasicCharBtnColor;
        DressBtn.color = ClasicDressBtnColor;
        AccBtn.color = PressAccBtnColor;
        arrangement();
    }
    /// <summary> ���� 1~10��° �������� �۵��ϴ� �Լ� </summary>
    /// <param name="nKey">���� ��ȣ</param>
    public void Slot1Active(int nKey)
    {
        CharBtnClick(); //ĳ���� ��ư Ȱ��ȭ
        #region ���� ���� �Լ�
        for (int i = 0; i < 10; i++) //��� ���� �ȴ��� ���·� �ʱ�ȭ
        {
            SlotBtnList[i].sprite = ClasicSlotBtn;
        }
        if (nKey == 0) //1��° ���� Ȱ��ȭ
        {
            SlotBtnList[nKey].sprite = PressSlotBtn;
            playerinform.ActiveSlotNumber = 1;
            LeftArrow.SetActive(false);
        }
        else if (nKey > 0 && nKey < 9) //2~9��° ���� Ȱ��ȭ 11
        {
            SlotBtnList[nKey].sprite = PressSlotBtn;
            playerinform.ActiveSlotNumber = nKey + 1;
            LeftArrow.SetActive(true);
            RightArrow.SetActive(true);
        }
        else if (nKey == 9) //10��° ���� Ȱ��ȭ
        {
            SlotBtnList[nKey].sprite = PressSlotBtn;
            playerinform.ActiveSlotNumber = 10;
            LeftArrow.SetActive(true);
            RightArrow.SetActive(false);
        }
        #endregion
        arrangement();
    }

    public void LiveStartBt() //���� ���� ��ư ��������
    {
        Loading.Instance.ChangeScene("12.Live");
    }
}
