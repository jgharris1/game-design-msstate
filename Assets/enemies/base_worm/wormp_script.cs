using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormp_script : MonoBehaviour
{
    public GameObject Followdata;
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
            Followdata = GameObject.FindWithTag("Player");
        }
        else
        {
            Followdata = transform.parent.GetChild(transform.GetSiblingIndex() - 1).gameObject;
        }
        foreach (Transform child in transform.parent)
        {
            if (child.GetSiblingIndex() != transform.GetSiblingIndex())
            {
                Physics2D.IgnoreCollision(child.GetComponent<Collider2D>(), transform.GetComponent<Collider2D>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        targetDif.Set(Followdata.transform.position.x - transform.position.x, Followdata.transform.position.y - transform.position.y, 0);
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
            transform.position = Followdata.transform.position - targetDif * Selfdata.segDist;
        }
    }

    public void damageApply(string attack)//, int statusId = 0, int statusLevel = 0, float duration = 0)
    {
        Selfdata.damageApply(attack);
    }
}
