using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormp_script : MonoBehaviour
{
    public GameObject Playerdata;
    public worm_data_script Selfdata;
    public Vector3 targetDif;
    public Vector3 targetPos;
    private bool head = false;
    // Start is called before the first frame update
    void Start()
    {
        targetDif = new Vector3(0.0f, 0.0f, 0.0f);
        targetPos = new Vector3(0.0f, 0.0f, 0.0f);
        Selfdata = transform.parent.gameObject.GetComponent<worm_data_script>();
        if (transform.GetSiblingIndex() == 0)
        {
            head = true;
        }
        if (head)
        {
            Playerdata = GameObject.FindWithTag("Player");
        }
        else
        {
            Playerdata = transform.parent.GetChild(transform.GetSiblingIndex() - 1).gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {
        targetDif.Set(Playerdata.transform.position.x - transform.position.x, Playerdata.transform.position.y - transform.position.y, 0);
        if ((Mathf.Abs(targetDif.x) + Mathf.Abs(targetDif.y)) != 0)
        {
            targetDif = Vector3.Normalize(targetDif);
        }
        if (head)
        {
            transform.position = transform.position + (targetDif * Selfdata.entitySpeed) * Time.deltaTime;
        }
        else
        {
            transform.position = Playerdata.transform.position - targetDif * Selfdata.segDist;
        }
    }
}
