using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worm_data_script : MonoBehaviour
{
    public float entitySpeed;
    public float segDist;
    public int health = 10;
    private damageData attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damageApply(string attackStr)//, int statusId = 0, int statusLevel = 0, float duration = 0)
    {
        attack = JsonUtility.FromJson<damageData>(attackStr);
        health -= attack.damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
