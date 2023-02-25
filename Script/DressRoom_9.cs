using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DressRoom_9 : MonoBehaviour
{
    [SerializeField] GameObject CharaSetpopbg;

    [SerializeField] GameObject DressScrollView;
    [SerializeField] GameObject AccScrollView;

    [SerializeField] Image SortBt1;
    [SerializeField] Image SortBt2;
    [SerializeField] Sprite SortBt;
    [SerializeField] Sprite SortBtClick;
    [SerializeField] Text SortBt1tx;
    [SerializeField] Text SortBt2tx;

    [SerializeField] Image Dressbt;
    [SerializeField] Image Accbt;

    [SerializeField] GameObject bg2Angle;

    // Start is called before the first frame update
    void Start()
    {
        SortBt1tx.text = "보유중";
        SortBt2tx.text = "모두";
        Dressbt.color = new Color(48f / 255f, 140f / 255f, 166f / 255f);
        SortBt1.sprite = SortBt;
        SortBt2.sprite = SortBtClick;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackBtn()
    {
        Loading.Instance.ChangeScene("2.Lobby");
    }
   /* public void EtcCharabtn() //다른 캐릭터 버튼 클릭
    {
        CharaSetpopbg.SetActive(true);
    }*/

    public void Dressbtpress()
    {
        SortBt1tx.text = "보유중";
        SortBt2tx.text = "모두";
        DressScrollView.SetActive(true);
        AccScrollView.SetActive(false);
        Dressbt.color = new Color(48f / 255f, 140f / 255f, 166f / 255f);
        Accbt.color = new Color(248f / 255f, 121f / 255f, 184f / 255f);
        bg2Angle.transform.DORotate(new Vector3(-20, 40, -360), 0.2f, RotateMode.FastBeyond360);
    }
    public void Accbtpress()
    {
        SortBt1tx.text = "입수순";
        SortBt2tx.text = "레어순";
        AccScrollView.SetActive(true);
        DressScrollView.SetActive(false);
        Accbt.color = new Color(159f / 255f, 55f / 255f, 107f / 255f);
        Dressbt.color = new Color(67f / 255f, 213f / 255f, 255f / 255f);
        bg2Angle.transform.DORotate(new Vector3(-20, 40, -360), 0.2f, RotateMode.FastBeyond360);
    }
    public void SortBt1Click()
    {
        SortBt1.sprite = SortBtClick;
        SortBt2.sprite = SortBt;
    }
    public void SortBt2Click()
    {
        SortBt1.sprite = SortBt;
        SortBt2.sprite = SortBtClick;
    }
}
