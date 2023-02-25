using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySelect_8 : MonoBehaviour
{
    [SerializeField] GameObject Choice1;
    [SerializeField] GameObject Choice2;
    int btnnumber = 1;
    public void BackBtn()
    {
        btnnumber -= 1;
        if(btnnumber == 0)
        {
            Loading2.Instance.ChangeScene("7.StoryMenu");
        }
        if(btnnumber == 1)
        {
            Choice1.SetActive(true);
            Choice2.SetActive(false);
        }
    }
    public void Choice()
    {
        btnnumber++;
        Choice1.SetActive(false);
        Choice2.SetActive(true);
    }
}
