using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryMenu_3 : MonoBehaviour
{
    [SerializeField] GameObject StoryMain;
    [SerializeField] GameObject MenuGroup;
    [SerializeField] GameObject MenuOpenButton;

    public void MenuOpen()
    {
        MenuGroup.SetActive(true);
        MenuOpenButton.SetActive(false);
    }
    public void Skip() => Debug.Log("SKIP");
    public void Log() => Debug.Log("Log");
    public void UiOff()
    {
        StoryMain.SetActive(false);
        MenuGroup.SetActive(false);
    }
    public void UiOn()
    {
        if (StoryMain.activeSelf == false)
        {
            StoryMain.SetActive(true);
            MenuGroup.SetActive(true);
        }
    }
    public void SkipStoty() => Debug.Log("SKIP");
    public void MenuClose()
    {
        MenuGroup.SetActive(false);
        MenuOpenButton.SetActive(true);
    }
}
