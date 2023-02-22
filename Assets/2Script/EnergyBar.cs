using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    [SerializeField] GameObject gamemanager;
    [SerializeField] RectTransform Activebar; //�ʷϻ� �������� 
    [SerializeField] Text TimerTX; //�������� Ÿ�̸�
    [SerializeField] Text ActiveText; //�������� ��ġ
    float timer;
    float energyexp; //���������� ��ġ�� �޾ƿ� ����
    void Start()
    {
        if (gamemanager == null) //�� ��ȯ�� ���ӸŴ��� �Ҵ�
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
