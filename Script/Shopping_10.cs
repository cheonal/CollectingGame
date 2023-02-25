using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Shopping_10 : MonoBehaviour
{
    [SerializeField] Image Passbt;
    [SerializeField] Image Dressbt;
    [SerializeField] Image Starbt;
    [SerializeField] GameObject PassShop;
    [SerializeField] GameObject DressShop;
    [SerializeField] GameObject StarShop;

    [SerializeField] GameObject bg2Angle;

    // Start is called before the first frame update
    void Start()
    {
        Passbt.color = new Color(48f / 255f, 140f / 255f, 166f / 255f);
        Dressbt.color = new Color(248f / 255f, 121f / 255f, 184f / 255f);
        Starbt.color = new Color(111f / 255f, 212f / 255f, 88f / 255f);
        PassShop.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackBtn()
    {
        Loading.Instance.ChangeScene("2.Lobby");
    }
    public void Passbtpress()
    {
        Passbt.color = new Color(48f / 255f, 140f / 255f, 166f / 255f);
        Dressbt.color = new Color(248f / 255f, 121f / 255f, 184f / 255f);
        Starbt.color = new Color(111f / 255f, 212f / 255f, 88f / 255f);
        PassShop.SetActive(true);
        DressShop.SetActive(false);
        StarShop.SetActive(false);
        bg2Angle.transform.DORotate(new Vector3(0, 0, -360), 0.2f, RotateMode.FastBeyond360);
    }
    public void Dressbtpress()
    {
        Passbt.color = new Color(67f / 255f, 213f / 255f, 255f / 255f);
        Dressbt.color = new Color(159f / 255f, 55f / 255f, 107f / 255f);
        Starbt.color = new Color(111f / 255f, 212f / 255f, 88f / 255f);
        PassShop.SetActive(false);
        DressShop.SetActive(true);
        StarShop.SetActive(false);
        bg2Angle.transform.DORotate(new Vector3(0, 0, -360), 0.2f, RotateMode.FastBeyond360);
    }
    public void Starbtpress()
    {
        Passbt.color = new Color(67f / 255f, 213f / 255f, 255f / 255f);
        Dressbt.color = new Color(248f / 255f, 121f / 255f, 184f / 255f);
        Starbt.color = new Color(58f / 255f, 171f / 255f, 32f / 255f);
        PassShop.SetActive(false);
        DressShop.SetActive(false);
        StarShop.SetActive(true);
        bg2Angle.transform.DORotate(new Vector3(0, 0, -360), 0.2f, RotateMode.FastBeyond360);
    }
}
