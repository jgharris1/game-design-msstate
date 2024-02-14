using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entitybasebehavior : MonoBehaviour
{
    public Vector3 targetPos;
    public Vector3 targetDif;
    public float entitySpeed;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector3(0.0f, 0.0f, 0.0f);
        targetDif = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        targetDif.Set(targetPos.x - transform.parent.position.x, targetPos.y - transform.parent.position.y, 0);
        if((Mathf.Abs(targetDif.x) + Mathf.Abs(targetDif.y)) != 0)
        {
            targetDif = Vector3.Normalize(targetDif);
        }
        transform.parent.position = transform.parent.position + (targetDif * entitySpeed) * Time.deltaTime;
    }
}
