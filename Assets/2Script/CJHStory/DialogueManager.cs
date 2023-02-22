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

    bool isDialogue = false; //��ȭ���� ��� true
    bool isNest = false; //Ư�� Ű �Է� ���

    int lintCount = 0; // ��ȭ ī��Ʈ
    int contextCount = 0; //��� ī��Ʈ

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
