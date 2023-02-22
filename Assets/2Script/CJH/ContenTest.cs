using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ContenTest : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Scrollbar scrollbar;
    [SerializeField] GameObject Content;
    [SerializeField] GameObject[] imglist;
    const int Size = 3;
    float[] pos = new float[Size];
    float distance;
    float curpos;
    float targetpos;
    bool isDrag;
    int tartgetIndex;
 

    private void Start()
    {
        for(int i = 0; i < imglist.Length; i++)
        {
            GameObject temp = Instantiate(imglist[i], this.transform.position, Quaternion.identity);
            temp.transform.SetParent(Content.transform);
        }

        distance = 1f / (Size - 1);
        for (int i=0; i<Size; i++)
        {
            pos[i] = distance * i;
        }

        
    }
    float SetPos()
    {
        for (int i = 0; i < Size; i++)
        {
            if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f)
            {
                tartgetIndex = i;
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
        isDrag = false;
        targetpos = SetPos();

        // ���ݰŸ��� ���� �ʰ� ���콺�� ������ �̵��ϸ�
        if (curpos == targetpos)
        {
            //18 ��ũ�� �ӵ� �� ���� ������ ��ǥ�� �ϳ� ����
            if (eventData.delta.x > 18 && curpos - distance >= 0)
            {
                --tartgetIndex;
                targetpos = curpos - distance;
            }
            //18 ��ũ�� �ӵ� �� ���� ������ ��ǥ�� �ϳ� ����
            else if (eventData.delta.x < -18 && curpos - distance <= 1.01f)
            {
                ++tartgetIndex;
                targetpos = curpos + distance;
            }
        }

    }

    void Update()
    {
        if (!isDrag)
        {
            scrollbar.value = Mathf.Lerp(scrollbar.value, targetpos, 0.1f);
        }
    }
}
