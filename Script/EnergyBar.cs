using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    [SerializeField] GameObject gamemanager;
    [SerializeField] RectTransform Activebar; //초록색 에너지바 
    [SerializeField] Text TimerTX; //에너지바 타이머
    [SerializeField] Text ActiveText; //에너지바 수치
    float timer;
    float energyexp; //에너지바의 수치를 받아올 변수
    void Start()
    {
        if (gamemanager == null) //씬 전환시 게임매니저 할당
        {
            gamemanager = GameObject.Find("GameManager");
        }
    }
    void Update()
    {
        timer = gamemanager.GetComponent<Gamemanager>().playerinform.energyfilltime;
        energyexp = gamemanager.GetComponent<Gamemanager>().playerinform.energyexp;
        Activebar.localScale = new Vector3((int)energyexp * (float)0.1, 1, 1);

        int min = (int)(timer / 60);
        int sec = (int)(timer % 60);
        string timeStr = string.Format("{0:00}:{1:00}", min, sec);
        TimerTX.text = timeStr;
        ActiveText.text = energyexp.ToString() + "/" + "10";

        if (energyexp == 10)
        {
            TimerTX.text = "Max";
        }
    }
}
