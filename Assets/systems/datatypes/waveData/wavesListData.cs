using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavesListData
{
    public string[] waves = new string[28];

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}
