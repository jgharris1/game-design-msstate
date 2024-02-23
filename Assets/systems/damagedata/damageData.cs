using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageData
{
    public int damage;
    public int statusId;
    public int statusLevel;
    public float statusDur;

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }

}
