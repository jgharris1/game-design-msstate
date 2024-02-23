using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybasescript : MonoBehaviour
{
    public GameObject Playerdata;
    public Vector3 targetDif;
    public float entitySpeed;
    // Start is called before the first frame update
    void Start()
    {
        Playerdata = GameObject.FindWithTag("Player");
        targetDif = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        targetDif.Set(Playerdata.transform.position.x - transform.position.x, Playerdata.transform.position.y - transform.position.y, 0);
        if ((Mathf.Abs(targetDif.x) + Mathf.Abs(targetDif.y)) != 0)
        {
            targetDif = Vector3.Normalize(targetDif);
        }
        transform.position = transform.position + (targetDif * entitySpeed) * Time.deltaTime;
    }
}
