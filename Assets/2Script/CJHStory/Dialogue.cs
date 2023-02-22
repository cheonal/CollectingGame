using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Tooltip("대사 아이디")]
    public string ID;

    [Tooltip("타이틀 번호")]
    public string TitleNum;

    [Tooltip("타이틀 이름")]
    public string Title;

    [Tooltip("캐릭터 이름")]
    public string Name;

    [Tooltip("대사 내용")]
    public string[] Contexts;

}
[System.Serializable]
public class DialogueEvent
{
    public string Name; //이벤트 이름 기능없음
    public Vector2 line; //대사 몇번째 부터 몇번째 대사를 가져올지
    public Dialogue[] dialogues;
}
