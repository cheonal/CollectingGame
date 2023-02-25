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
    int This_listnum;
    void Start()
    {
        List<Dictionary<string, object>> Questdata = CSVReader.Read("DataQuest");
        questminiTitletxt.text = Questdata[This_listnum]["questminiTitle"].ToString();
        questTitletxt.text = Questdata[This_listnum]["questTitle"].ToString();
        questTxttxt.text = Questdata[This_listnum]["questTxt"].ToString();
        questRewardtxt.text = Questdata[This_listnum]["questReward"].ToString();
        questRewardNumtxt.text = Questdata[This_listnum]["questRewardNum"].ToString();
    }
    public void num(int listnum)
    {
        This_listnum = listnum;
    }


}
