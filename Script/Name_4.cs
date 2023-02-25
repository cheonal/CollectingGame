using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name_4 : MonoBehaviour
{
    public InputField InputName;

    public void Save()
    {
        PlayerPrefs.SetString("UserName", InputName.text);
    }
    public void Load()
    {
        Debug.Log(PlayerPrefs.GetString("UserName"));
    }
}
