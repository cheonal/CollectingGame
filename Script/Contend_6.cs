using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contend_6 : MonoBehaviour
{
    [SerializeField] GameObject DailyMissonImg;
    public GameObject [] imglist;
    public void Start()
    {
        List<Dictionary<string, object>> Questdata = CSVReader.Read("DataQuest");
        imglist = new GameObject[Questdata.Count];

        for (int i = 0; i < Questdata.Count; i++)
        {
            imglist[i] = Instantiate(DailyMissonImg, transform.position, transform.rotation);
            imglist[i].transform.SetParent(this.transform, false);
            imglist[i].GetComponent<QuestList_6>().num(i);
        }
    }


}
