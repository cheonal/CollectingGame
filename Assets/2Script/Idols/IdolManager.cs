using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Data
{
    public float Hp;
}
public abstract class IdolManager : MonoBehaviour
{
    public Data data;

    public abstract void Setting();

  //  public abstract void Using();
}
