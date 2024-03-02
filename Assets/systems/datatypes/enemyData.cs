using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyData
{
    public string name;
    public int HP;
    public float speed;
    public float XP;
    public int animFrames;
    public float frameRate;

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}
