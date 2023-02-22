using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestList_6 : MonoBehaviour
{
    [SerializeField] Text questminiTitletxt;
    [SerializeField] Text questTitletxt;
    [SerializeField] Text questTxttxt;
    [SerializeField] Text questRewardtxt;
    [SerializeField] Text questRewardNumtxt;
    int listnum;
    void Start()
    {
        List<Dictionary<string, object>> Questdata = CSVReader.Read("DataQuest");
        questminiTitletxt.text = Questdata[listnum]["questminiTitle"].ToString();
        questTitletxt.text = Questdata[listnum]["questTitle"].ToString();
        questTxttxt.text = Questdata[listnum]["questTxt"].ToString();
        questRewardtxt.text = Questdata[listnum]["questReward"].ToString();
        questRewardNumtxt.text = Questdata[listnum]["questRewardNum"].ToString();
    }
    public void num(int ad)
    {
        listnum = ad;
    }


}
