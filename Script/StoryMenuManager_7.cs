using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryMenuManager_7 : MonoBehaviour
{
    public void BackBtn()
    {
        Loading.Instance.ChangeScene("2.Lobby");
    }
    public void EventStory() => Debug.Log("EventStory");
    public void MainStory()
    {
        Loading2.Instance.ChangeScene("7_5.StorySelect");
    }
    public void StillAlbum() => Debug.Log("StillAlbum");

}
