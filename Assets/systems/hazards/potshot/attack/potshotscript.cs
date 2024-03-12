using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potshotscript : MonoBehaviour
{
    public GameObject Playerdata;
    public Vector3 targetDif;
    public float entitySpeed;
    public bool lineFollow = false;
    public float immuneFrame = 0;
    private damageData attackout;
    public int damage;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        Playerdata = GameObject.FindGameObjectWithTag("Player");
        attackout = new damageData();
        attackout.damage = damage;
        attackout.statusId = 0;
        attackout.statusLevel = 0;
        attackout.statusDur = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (targetDif * entitySpeed) * Time.deltaTime;
        if (Vector3.Distance(Playerdata.transform.position, transform.position) > range)//100 is arbitrary, just has to be offscreen
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")//will need to be an enemy tag if multiple enemies
        {
            collision.gameObject.SendMessage("damageApply", attackout.SaveToString());
        }
    }

    public void setpoint(Vector3 point)
    {
        targetDif = new Vector3(0.0f, 0.0f, 0.0f);
        targetDif.Set(point.x - transform.position.x, point.y - transform.position.y, 0);
        targetDif = Vector3.Normalize(targetDif);
        transform.Rotate(0f, 0f, -(Mathf.Atan2(targetDif.x, targetDif.y) * Mathf.Rad2Deg) + 90, Space.Self);
    }
}
