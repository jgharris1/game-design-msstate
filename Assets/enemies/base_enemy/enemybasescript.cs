using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybasescript : MonoBehaviour
{
    public GameObject Playerdata;
    public Vector3 targetDif;
    public int health = 10;
    public float entitySpeed;
    public bool lineFollow = false;
    // Start is called before the first frame update
    void Start()
    {
        Playerdata = GameObject.FindWithTag("Player");
        targetDif = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!lineFollow)
        {
            targetDif.Set(Playerdata.transform.position.x - transform.position.x, Playerdata.transform.position.y - transform.position.y, 0);
            if ((Mathf.Abs(targetDif.x) + Mathf.Abs(targetDif.y)) != 0)
            {
                targetDif = Vector3.Normalize(targetDif);
            }
        }
        transform.position = transform.position + (targetDif * entitySpeed) * Time.deltaTime;
    }

    void setDir(Vector3 tempDir)
    {
        lineFollow = true;
        targetDif.Set(tempDir.x, tempDir.y, 0);
    }

    [ContextMenu("Apply Damage")]
    public void damageApply()//int damage, int statusId = 0, int statusLevel = 0, float duration = 0)
    {
        health -= 1;
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
