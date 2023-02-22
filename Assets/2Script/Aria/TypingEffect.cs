using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    public TMP_Text tx;
    string Script;

    // Start is called before the first frame update
    void Start()
    {
        Script = tx.text; //어떤 대사를 넣을지 String값 가져오기
        StartCoroutine(Typing(Script));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Typing(string talk)
    {
        tx.text = null;

        if (talk.Contains("/")) talk = talk.Replace("/", "\n"); //슬래시 들어가면 줄바꿈

        for (int i = 0; i < talk.Length; i++)
        {
            tx.text += talk[i];
            yield return new WaitForSeconds(0.05f); //타이핑 속도
        }
    }
}
