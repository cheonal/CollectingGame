using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollSnap : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //5번 Scene 적용 세로 스크롤
    [SerializeField] Scrollbar scrollbar;

    const int SIZE = 7;
    float[] pos = new float[SIZE];
    float distance;

    float targetpos;
    bool Drag;
    bool Click;
    string Clickbanner;

    // Start is called before the first frame update
    void Start()
    {
        scrollbar.value = 1;
        targetpos = 1;
        distance = 1f / (SIZE - 1);
        for (int i = 0; i < SIZE; i++) pos[i] = distance * i;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        Drag = true;
        Click = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Drag = false;

        for (int i = 0; i < SIZE; i++)
        {
            if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f)
            {
                targetpos = pos[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Drag && !Click)
        {
            scrollbar.value = Mathf.Lerp(scrollbar.value, targetpos, 0.1f);
        }

        if (Click == true)
        {
            scrollbar.value = Mathf.Lerp(scrollbar.value, 1 - pos[int.Parse(Clickbanner)], 0.1f);
        }
    }

    public void btclick()
    {
        Click = true;
        Clickbanner = EventSystem.current.currentSelectedGameObject.name;
    }
}
