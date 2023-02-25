using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage_11 : MonoBehaviour
{
    [SerializeField] GameObject StageGroup;
    [SerializeField] GameObject ChoiceGroup;
    int btnnumber = 1;

    public void Stage1()
    {
        btnnumber++;
        StageGroup.SetActive(false);
        ChoiceGroup.SetActive(true);
    }
    public void Stage2()
    {
        btnnumber++;
        StageGroup.SetActive(false);
        ChoiceGroup.SetActive(true);
    }
    public void Stage3()
    {
        btnnumber++;
        StageGroup.SetActive(false);
        ChoiceGroup.SetActive(true);
    }
    public void Stage4()
    {
        btnnumber++;
        StageGroup.SetActive(false);
        ChoiceGroup.SetActive(true);
    }
    public void BackBtn()
    {
        btnnumber -= 1;
        if (btnnumber == 0)
        {
            Loading.Instance.ChangeScene("2.Lobby");
            //SceneManager.LoadScene("2.Lobby");
        }
        if (btnnumber == 1)
        {
            StageGroup.SetActive(true);
            ChoiceGroup.SetActive(false);
        }
    }
    public void StageStart()
    {
        Loading2.Instance.ChangeScene("11_5.StageSet");
    }

}
