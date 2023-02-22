using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class Test3 : MonoBehaviour
{
    public GameObject []itemPrefab;
    public List<int> dataList;
    private ScrollRect _scroll;
    private List<GameObject> itemList;
    public RectTransform tt;
    public float scrollWeight;
    public float itemWeight = 510;
    private void Awake()
    {
        _scroll = GetComponent<ScrollRect>();
    }
    private void Start()
    {
        dataList.Clear();
        for(int i = 0; i < 100; i++)
        {
            dataList.Add(i);
        }
        CreateItem();
        SetContentHight();
        tt.anchoredPosition = new Vector2(-26000, 0);
    }

    private void CreateItem()
    {
        RectTransform scrollRect = _scroll.GetComponent<RectTransform>();
        itemList = new List<GameObject>();

        int itemCount = (int)(scrollRect.rect.width / itemWeight) * 2;
        for(int i = 0; i < itemCount; i++)
        {
            for(int j=0; j < itemPrefab.Length; j++)
            {
                GameObject item = Instantiate(itemPrefab[j], _scroll.content);
                itemList.Add(item);
                item.transform.localPosition = new Vector3(i * itemWeight, 0);
            }
        }
    }
    void SetContentHight()
    {
        _scroll.content.sizeDelta = new Vector2(dataList.Count * itemWeight, _scroll.content.sizeDelta.y);
    }
    private void RelocationItem(GameObject item, float contentX) 
    {
        RectTransform scrollRect = _scroll.GetComponent<RectTransform>();
        scrollWeight = scrollRect.rect.width;
        if (item.transform.localPosition.x + contentX < -itemWeight * 3)
        {
            item.transform.localPosition += new Vector3(itemList.Count * itemWeight, 0);
        }
        else if (item.transform.localPosition.x + contentX > itemWeight *3)
        {
            item.transform.localPosition -= new Vector3(itemList.Count * itemWeight, 0);
        }
    }
    private void Update()
    {
        float contentX = _scroll.content.anchoredPosition.x;
        foreach (GameObject item in itemList)
        {
            RelocationItem(item, contentX);
        }
    }
}
