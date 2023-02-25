using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdolsChoic_5 : MonoBehaviour
{
    [SerializeField] GameObject BtnGroup;
    [SerializeField] GameObject IdolsMenuGroup;

    public void IdolsChoiceBtn()
    {
        BtnGroup.SetActive(false);
        IdolsMenuGroup.SetActive(true);

    }
    public void BackBtn()
    {
        BtnGroup.SetActive(true);
        IdolsMenuGroup.SetActive(false);
    }
    public void IdolsChooseBtn()
    {
        Debug.Log("선택완료");
    }
}
