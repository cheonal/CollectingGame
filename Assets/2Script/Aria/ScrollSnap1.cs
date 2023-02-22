using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ScrollSnap1 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //2번 Scene 적용 가로 스크롤
    [SerializeField] Scrollbar scrollbar;

    const int SIZE = 3;
    float[] pos = new float[SIZE];
    float distance;

    float targetpos;
    bool Drag;

    int currentPage; //현재 스크롤에서 보여지고 있는 배너의 번호

    [SerializeField] GameObject[] Ball; //배너 왼쪽 하단에 표시중인 작은 원형의 오브젝트
    [SerializeField] Sprite fillball; //위 ball오브젝트가 채워진 모양의 sprite
    [SerializeField] Sprite emptyball; //위 ball오브젝트가 비워진 모양의 sprite

    // Start is called before the first frame update
    void Start()
    {
        currentPage = 0;
        scrollbar.value = 0;
        targetpos = 0;
        distance = 1f / (SIZE - 1);
        for (int i = 0; i < SIZE; i++) pos[i] = distance * i;

        InvokeRepeating("SlideMove", 3f, 3f); //3초마다 스크롤을 자동으로 움직이게 만드는 함수를 불러옴
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

        for (int i = 0; i < SIZE; i++) //SIZE는 현재 스크롤에 들어간 총 배너의 갯수
        {
            if (i == currentPage) //스크롤에 보여지고 있는 배너번호(currentPage)가 i와 동일할 경우에만
            {
                Ball[i].GetComponent<Image>().sprite = fillball; //채워진 ball오브젝트가 보이도록
            }
            else
            {
                Ball[i].GetComponent<Image>().sprite = emptyball; //아닌 경우는 비어진 ball오브젝트가 보이도록
            }
        }
    }

    void SlideMove() //스크롤이 자동으로 움직이게 만들 함수
    {
        if (currentPage != SIZE - 1) //현재 보여지고 있는 배너가 [SIZE(현재 스크롤에 들어간 총 배너의 갯수)의 -1]과 같지 않으면 현재 배너번호를 1씩 추가하며 다음 배너가 보이도록 이동
        {                            //[SIZE(현재 스크롤에 들어간 총 배너의 갯수)의 -1] <-를 사용한 이유는 List의 번호가 1부터 시작하는게 아닌 0부터 시작하기 때문
            currentPage++;
            targetpos = pos[currentPage];
        }
        else
        {
            currentPage = 0; //현재 보여지고 있는 배너가 [SIZE(현재 스크롤에 들어간 총 배너의 갯수)의 -1]과 같으면 다시 첫 배너로 가야하니까 첫 배너의 번호인 0을 대입
            targetpos = pos[currentPage];
        }
    }

    public void prevPage() //배너 오른쪽 하단 < 화살표 버튼을 클릭하면 불러올 함수
    {
        if (0 < currentPage) //현재 스크롤에서 보여지고 있는 배너의 번호(currentPage)가 0보다 크면
        {
            currentPage--; //배너 번호를 -1 해서 이전 배너가 보이도록
            targetpos = pos[currentPage];
        }
    }

    public void nextPage() //배너 오른쪽 하단 > 화살표 버튼을 클릭하면 불러올 함수
    {
        if (currentPage < SIZE - 1) //현재 스크롤에서 보여지고 있는 배너의 번호(currentPage)가 [SIZE(현재 스크롤에 들어간 총 배너의 갯수)의 -1]보다 작으면
        {
            currentPage++; //배너 번호를 +1 해서 다음 배너가 보이도록
            targetpos = pos[currentPage];
        }
    }
}