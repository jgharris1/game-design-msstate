using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuckshotScript : MonoBehaviour
{
    public entitybasebehavior Selfdata;
    public Vector3 buckshotDir;
    public float speed;
    public float startPosOffset;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        buckshotDir = player.GetComponent<Vector3>();//GetComponent is janky and if there is another Vector3 added to PlayerBaseScript, more specificity will be needed

        if (buckshotDir.x == 0.0f)
        {
            buckshotDir.x += startPosOffset;
        }

        if (buckshotDir.y == 0.0f)
        {
            buckshotDir.y += startPosOffset;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
