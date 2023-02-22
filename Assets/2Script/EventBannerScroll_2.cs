using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class EventBannerScroll_2 : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //이미지의 가로 크기
    float itemWidth = 510;

    //사이즈 조절
    const int Size = 100;
    public float[] pos = new float[Size];

    [SerializeField] Scrollbar scrollbar;
    [SerializeField] GameObject[] Ball; //배너 왼쪽 하단에 표시중인 작은 원형의 오브젝트
    [SerializeField] Sprite fillball; //위 ball오브젝트가 채워진 모양의 sprite
    [SerializeField] Sprite emptyball; //위 ball오브젝트가 비워진 모양의 sprite

    float distance; //버튼 사이의 거리 함수
    float curpos; //현재 위치
    float targetpos; //다음 위치
    float Page; //몇번째 프리팹인지 알려주는 함수
    float SlideTime; //유저 터치, 시간체크 함수
    bool isDrag;

    public GameObject[] itemPrefab; //이미지 프리팹 그룹
    private ScrollRect _scroll;
    public List<int> dataList;
    private List<GameObject> itemList;

    //오류 시 이미지, 스크롤뷰, Content의 pivot 체크

    void Awake()
    {
        _scroll = GetComponent<ScrollRect>();
    }
    void Start()
    {
        //시작 시 스크롤뷰 밸류 조정
        targetpos = (float)0.5151515;

        //Content 크기를 이미지 * 100 으로 설정했으니 Size를 100으로 맞춰서 함수 설정 
        distance = 1f / (Size - 1);

        //슬라이드 되는 칸마다의 수치 설정
        for (int i = 0; i < Size; i++)
        {
            pos[i] = distance * i;
        }
        CreateItem();
        SetContentWidth();
    }
    void Update()
    {
        //시간을 체크해 3초가 지나면 다음 페이지로 이동
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
    /// 이벤트 배너 하단 볼 이미지 업데이트 스크립트
    /// </summary>
    void BallEvent()
    {
        //단순 (int) 사용시 반올림 오류 발생
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
    /// Content 하위에 이미지 프리팹을 생성하는 스크립트
    /// </summary>
    void CreateItem()
    {
        itemList = new List<GameObject>();
        //두 그룹 생성해서 자연스럽게 보이도록 설정
        for (int i = 0; i < 2; i++)
        {
            //생성할 아이템의 크기에 맞춰 Content 하위 오브젝트에 위치 지정해서 생성, 프리팹에 배열로 넣은 순서대로 생성
            for (int j = 0; j < itemPrefab.Length; j++)
            {
                GameObject item = Instantiate(itemPrefab[j], _scroll.content);
                itemList.Add(item);
                item.transform.localPosition = new Vector3(i * itemWidth, 0);
            }
        }
    }
    /// <summary>
    /// Content 크기 조정 스크립트
    /// </summary>
    void SetContentWidth()
    {
        // 사용시 스크롤바 초기 벨류를 지정할 수 없어서 일단 보류하겠습니다
        // _scroll.content.sizeDelta = new Vector2(Size * itemWidth, _scroll.content.sizeDelta.y);
    }
    /// <summary>
    /// 프리팹 게임 오브젝트 위치 재조정 스크립트
    /// </summary>
    /// <param name="item">화면에 보여지는 이벤트 배너 버튼</param>
    /// <param name="contentX">스크롤해서 변화하는 Content X좌표</param>
    void RelocationItem(GameObject item, float contentX)
    {
        // 오브젝트 넓이보다 x좌표 -3배 위치로 이동하면 좌표 이동 (3칸 이동시)
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
    /// 드래그 시작, 끝낼경우 수치 반환 스크립트
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
        // 절반거리를 넘지 않고 마우스를 빠르게 이동하면
        if (curpos == targetpos)
        {
            //18 스크롤 속도 ◀ 으로 가려면 목표가 하나 감소
            if (eventData.delta.x > 18 && curpos - distance >= 0)
            {
                targetpos = curpos - distance;
            }
            //18 스크롤 속도 ▶ 으로 가려면 목표가 하나 감소
            else if (eventData.delta.x < -18 && curpos - distance <= 1.01f)
            {
                targetpos = curpos + distance;
            }
        }
    }
    public void prevPage() //배너 오른쪽 하단 < 화살표 버튼을 클릭하면 불러올 함수
    {
        SlideTime = 0;
        targetpos -= distance;
    }

    public void nextPage() //배너 오른쪽 하단 > 화살표 버튼을 클릭하면 불러올 함수
    {
        SlideTime = 0;
        targetpos += distance;
    }
}
