using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject go_DialogueBar;
    [SerializeField] GameObject go_DialogueNameBar;

    [SerializeField] TextMeshProUGUI StoryMainTxt;
    [SerializeField] Text StoryNameTxt;

    bool isDialogue = false; //대화중일 경우 true
    bool isNest = false; //특정 키 입력 대기

    int lintCount = 0; // 대화 카운트
    int contextCount = 0; //대사 카운트

    Dialogue[] dialogues;

    public void ShowDialogue(Dialogue[] p_dialogues)
    {
        StoryMainTxt.text = "";
        StoryNameTxt.text = "";
        dialogues = p_dialogues;

        StartCoroutine(TypeWriter());
    }

    IEnumerator TypeWriter()
    {
        SettingUI(true);
        string t_ReplaceText = dialogues[lintCount].Contexts[contextCount];
        t_ReplaceText = t_ReplaceText.Replace("'", ",");

        StoryMainTxt.text = t_ReplaceText;

        isNest = true;
        yield return null;
    }

    void SettingUI(bool p_flag)
    {
        go_DialogueBar.SetActive(p_flag);
        go_DialogueNameBar.SetActive(p_flag);
    }
}
