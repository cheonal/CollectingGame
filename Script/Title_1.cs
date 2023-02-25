using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_1 : MonoBehaviour
{
    [SerializeField] GameObject MenuGroup;

    public void ToLobby() => Loading.Instance.ChangeScene("2.Lobby"); //SceneManager.LoadScene("2.Lobby"); //ȭ���� Ŭ���ϸ� �κ� ������ �Ѿ
    public void OpenMenu() => MenuGroup.SetActive(true); //�޴� �׷� Ȱ��ȭ
    public void CloseMenu() => MenuGroup.SetActive(false); //�޴� �׷� ��Ȱ��ȭ
    public void ToNotice() => Debug.Log("�������� Ȯ��"); //�������� Ȯ��
    public void ToCafe() => Debug.Log("����ī�� �̵�"); //����ī�� �̵�
    public void LogOut() => Debug.Log("�α׾ƿ�"); //�α׾ƿ�
}
