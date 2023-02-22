using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Tooltip("��� ���̵�")]
    public string ID;

    [Tooltip("Ÿ��Ʋ ��ȣ")]
    public string TitleNum;

    [Tooltip("Ÿ��Ʋ �̸�")]
    public string Title;

    [Tooltip("ĳ���� �̸�")]
    public string Name;

    [Tooltip("��� ����")]
    public string[] Contexts;

}
[System.Serializable]
public class DialogueEvent
{
    public string Name; //�̺�Ʈ �̸� ��ɾ���
    public Vector2 line; //��� ���° ���� ���° ��縦 ��������
    public Dialogue[] dialogues;
}
