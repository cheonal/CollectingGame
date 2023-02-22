using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ScrollSnap1 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //2�� Scene ���� ���� ��ũ��
    [SerializeField] Scrollbar scrollbar;

    const int SIZE = 3;
    float[] pos = new float[SIZE];
    float distance;

    float targetpos;
    bool Drag;

    int currentPage; //���� ��ũ�ѿ��� �������� �ִ� ����� ��ȣ

    [SerializeField] GameObject[] Ball; //��� ���� �ϴܿ� ǥ������ ���� ������ ������Ʈ
    [SerializeField] Sprite fillball; //�� ball������Ʈ�� ä���� ����� sprite
    [SerializeField] Sprite emptyball; //�� ball������Ʈ�� ����� ����� sprite

    // Start is called before the first frame update
    void Start()
    {
        currentPage = 0;
        scrollbar.value = 0;
        targetpos = 0;
        distance = 1f / (SIZE - 1);
        for (int i = 0; i < SIZE; i++) pos[i] = distance * i;

        InvokeRepeating("SlideMove", 3f, 3f); //3�ʸ��� ��ũ���� �ڵ����� �����̰� ����� �Լ��� �ҷ���
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        Drag = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Drag = false;

        for (int i = 0; i < SIZE; i++)
        {
            if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f)
            {
                targetpos = pos[i];
                currentPage = i;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Drag == false)
        {
            scrollbar.value = Mathf.Lerp(scrollbar.value, targetpos, 0.1f);
        }

        for (int i = 0; i < SIZE; i++) //SIZE�� ���� ��ũ�ѿ� �� �� ����� ����
        {
            if (i == currentPage) //��ũ�ѿ� �������� �ִ� ��ʹ�ȣ(currentPage)�� i�� ������ ��쿡��
            {
                Ball[i].GetComponent<Image>().sprite = fillball; //ä���� ball������Ʈ�� ���̵���
            }
            else
            {
                Ball[i].GetComponent<Image>().sprite = emptyball; //�ƴ� ���� ����� ball������Ʈ�� ���̵���
            }
        }
    }

    void SlideMove() //��ũ���� �ڵ����� �����̰� ���� �Լ�
    {
        if (currentPage != SIZE - 1) //���� �������� �ִ� ��ʰ� [SIZE(���� ��ũ�ѿ� �� �� ����� ����)�� -1]�� ���� ������ ���� ��ʹ�ȣ�� 1�� �߰��ϸ� ���� ��ʰ� ���̵��� �̵�
        {                            //[SIZE(���� ��ũ�ѿ� �� �� ����� ����)�� -1] <-�� ����� ������ List�� ��ȣ�� 1���� �����ϴ°� �ƴ� 0���� �����ϱ� ����
            currentPage++;
            targetpos = pos[currentPage];
        }
        else
        {
            currentPage = 0; //���� �������� �ִ� ��ʰ� [SIZE(���� ��ũ�ѿ� �� �� ����� ����)�� -1]�� ������ �ٽ� ù ��ʷ� �����ϴϱ� ù ����� ��ȣ�� 0�� ����
            targetpos = pos[currentPage];
        }
    }

    public void prevPage() //��� ������ �ϴ� < ȭ��ǥ ��ư�� Ŭ���ϸ� �ҷ��� �Լ�
    {
        if (0 < currentPage) //���� ��ũ�ѿ��� �������� �ִ� ����� ��ȣ(currentPage)�� 0���� ũ��
        {
            currentPage--; //��� ��ȣ�� -1 �ؼ� ���� ��ʰ� ���̵���
            targetpos = pos[currentPage];
        }
    }

    public void nextPage() //��� ������ �ϴ� > ȭ��ǥ ��ư�� Ŭ���ϸ� �ҷ��� �Լ�
    {
        if (currentPage < SIZE - 1) //���� ��ũ�ѿ��� �������� �ִ� ����� ��ȣ(currentPage)�� [SIZE(���� ��ũ�ѿ� �� �� ����� ����)�� -1]���� ������
        {
            currentPage++; //��� ��ȣ�� +1 �ؼ� ���� ��ʰ� ���̵���
            targetpos = pos[currentPage];
        }
    }
}