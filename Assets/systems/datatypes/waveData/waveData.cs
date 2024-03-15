using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveData
{
    public int timeGoal;
    public string[] enemies = new string[2];
    public float ratio;
    public int mobCap;
    public float spawnRate;
    public string hazard;


    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}
