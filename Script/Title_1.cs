using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_1 : MonoBehaviour
{
    [SerializeField] GameObject MenuGroup;

    public void ToLobby() => Loading.Instance.ChangeScene("2.Lobby"); //SceneManager.LoadScene("2.Lobby"); //화면을 클릭하면 로비 씬으로 넘어감
    public void OpenMenu() => MenuGroup.SetActive(true); //메뉴 그룹 활성화
    public void CloseMenu() => MenuGroup.SetActive(false); //메뉴 그룹 비활성화
    public void ToNotice() => Debug.Log("공지사항 확인"); //공지사항 확인
    public void ToCafe() => Debug.Log("공식카페 이동"); //공식카페 이동
    public void LogOut() => Debug.Log("로그아웃"); //로그아웃
}
