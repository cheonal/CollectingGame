using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class EventBannerScroll_2 : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //�̹����� ���� ũ��
    float itemWidth = 510;

    //������ ����
    const int Size = 100;
    public float[] pos = new float[Size];

    [SerializeField] Scrollbar scrollbar;
    [SerializeField] GameObject[] Ball; //��� ���� �ϴܿ� ǥ������ ���� ������ ������Ʈ
    [SerializeField] Sprite fillball; //�� ball������Ʈ�� ä���� ����� sprite
    [SerializeField] Sprite emptyball; //�� ball������Ʈ�� ����� ����� sprite

    float distance; //��ư ������ �Ÿ� �Լ�
    float curpos; //���� ��ġ
    float targetpos; //���� ��ġ
    float Page; //���° ���������� �˷��ִ� �Լ�
    float SlideTime; //���� ��ġ, �ð�üũ �Լ�
    bool isDrag;

    public GameObject[] itemPrefab; //�̹��� ������ �׷�
    private ScrollRect _scroll;
    public List<int> dataList;
    private List<GameObject> itemList;

    //���� �� �̹���, ��ũ�Ѻ�, Content�� pivot üũ

    void Awake()
    {
        _scroll = GetComponent<ScrollRect>();
    }
    void Start()
    {
        //���� �� ��ũ�Ѻ� ��� ����
        targetpos = (float)0.5151515;

        //Content ũ�⸦ �̹��� * 100 ���� ���������� Size�� 100���� ���缭 �Լ� ���� 
        distance = 1f / (Size - 1);

        //�����̵� �Ǵ� ĭ������ ��ġ ����
        for (int i = 0; i < Size; i++)
        {
            pos[i] = distance * i;
        }
        CreateItem();
        SetContentWidth();
    }
    void Update()
    {
        //�ð��� üũ�� 3�ʰ� ������ ���� �������� �̵�
        SlideTime += Time.deltaTime;
        if (SlideTime > 3)
        {
            nextPage();
        }

        float contentX = _scroll.content.anchoredPosition.x;
        foreach (GameObject item in itemList)
        {
            RelocationItem(item, contentX);
        }

        if (!isDrag)
        {
            scrollbar.value = Mathf.Lerp(scrollbar.value, targetpos, 0.1f);
        }

        BallEvent();
    }
    /// <summary>
    /// �̺�Ʈ ��� �ϴ� �� �̹��� ������Ʈ ��ũ��Ʈ
    /// </summary>
    void BallEvent()
    {
        //�ܼ� (int) ���� �ݿø� ���� �߻�
        Page = Mathf.Round(targetpos * 99f);
        for (int j = 0; j < 3; j++)
        {
            if (Page % 3 == j)
                Ball[j].GetComponent<Image>().sprite = fillball;
            else
                Ball[j].GetComponent<Image>().sprite = emptyball;
        }
    }
    /// <summary>
    /// Content ������ �̹��� �������� �����ϴ� ��ũ��Ʈ
    /// </summary>
    void CreateItem()
    {
        itemList = new List<GameObject>();
        //�� �׷� �����ؼ� �ڿ������� ���̵��� ����
        for (int i = 0; i < 2; i++)
        {
            //������ �������� ũ�⿡ ���� Content ���� ������Ʈ�� ��ġ �����ؼ� ����, �����տ� �迭�� ���� ������� ����
            for (int j = 0; j < itemPrefab.Length; j++)
            {
                GameObject item = Instantiate(itemPrefab[j], _scroll.content);
                itemList.Add(item);
                item.transform.localPosition = new Vector3(i * itemWidth, 0);
            }
        }
    }
    /// <summary>
    /// Content ũ�� ���� ��ũ��Ʈ
    /// </summary>
    void SetContentWidth()
    {
        // ���� ��ũ�ѹ� �ʱ� ������ ������ �� ��� �ϴ� �����ϰڽ��ϴ�
        // _scroll.content.sizeDelta = new Vector2(Size * itemWidth, _scroll.content.sizeDelta.y);
    }
    /// <summary>
    /// ������ ���� ������Ʈ ��ġ ������ ��ũ��Ʈ
    /// </summary>
    /// <param name="item">ȭ�鿡 �������� �̺�Ʈ ��� ��ư</param>
    /// <param name="contentX">��ũ���ؼ� ��ȭ�ϴ� Content X��ǥ</param>
    void RelocationItem(GameObject item, float contentX)
    {
        // ������Ʈ ���̺��� x��ǥ -3�� ��ġ�� �̵��ϸ� ��ǥ �̵� (3ĭ �̵���)
        if (item.transform.localPosition.x + contentX < -itemWidth * 3)
        {
            item.transform.localPosition += new Vector3(itemList.Count * itemWidth, 0);
        }
        else if (item.transform.localPosition.x + contentX > itemWidth * 3)
        {
            item.transform.localPosition -= new Vector3(itemList.Count * itemWidth, 0);
        }
    }
    /// <summary>
    /// �巡�� ����, ������� ��ġ ��ȯ ��ũ��Ʈ
    /// </summary>
    float SetPos()
    {
        for (int i = 0; i < Size; i++)
        {
            if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f)
            {
                return pos[i];
            }
        }
        return 0;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        curpos = SetPos();
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        SlideTime = 0;
        isDrag = false;
        targetpos = SetPos();
        // ���ݰŸ��� ���� �ʰ� ���콺�� ������ �̵��ϸ�
        if (curpos == targetpos)
        {
            //18 ��ũ�� �ӵ� �� ���� ������ ��ǥ�� �ϳ� ����
            if (eventData.delta.x > 18 && curpos - distance >= 0)
            {
                targetpos = curpos - distance;
            }
            //18 ��ũ�� �ӵ� �� ���� ������ ��ǥ�� �ϳ� ����
            else if (eventData.delta.x < -18 && curpos - distance <= 1.01f)
            {
                targetpos = curpos + distance;
            }
        }
    }
    public void prevPage() //��� ������ �ϴ� < ȭ��ǥ ��ư�� Ŭ���ϸ� �ҷ��� �Լ�
    {
        SlideTime = 0;
        targetpos -= distance;
    }

    public void nextPage() //��� ������ �ϴ� > ȭ��ǥ ��ư�� Ŭ���ϸ� �ҷ��� �Լ�
    {
        SlideTime = 0;
        targetpos += distance;
    }
}
