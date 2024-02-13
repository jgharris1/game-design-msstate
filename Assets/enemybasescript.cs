using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybasescript : MonoBehaviour
{
    public GameObject Playerdata;
    public entitybasebehavior Selfdata;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Selfdata.targetPos.Set(Playerdata.transform.position.x, Playerdata.transform.position.y, 0);
    }
}
