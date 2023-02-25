using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Story_3 : MonoBehaviour
{
    [SerializeField] Text IdolsName;
    [SerializeField] Text IdolsStory;   
    [SerializeField] Image Idols;
    Dictionary<int, string[]> talkData;
    [SerializeField] GameObject StoryCursor;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    void GenerateData()
    {
        talkData.Add(1,new string[] {"안녕하세요 저는 이시아 에요"});
    }
}
