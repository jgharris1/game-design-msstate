using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveScript : MonoBehaviour
{
    //public entitybasebehavior Selfdata;
    public Vector3 bulletDir;
    public GameObject Playerdata;
    public float speed;
    public float range;
    public float pierce;
    public damageData attack;
    public int damage;
    public int statusId;
    public int statusLevel;
    public float statusDur;

    // Start is called before the first frame update
    void Start()
    {
        attack = new damageData();
        attack.damage = damage;
        attack.statusId = statusId;
        attack.statusLevel = statusLevel;
        attack.statusDur = statusDur;
        Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Playerdata = GameObject.FindWithTag("Player");
        bulletDir.Set(mPosition.x - transform.position.x, mPosition.y - transform.position.y, 0);
        if ((Mathf.Abs(bulletDir.x) + Mathf.Abs(bulletDir.y)) != 0)
        {
            bulletDir = Vector3.Normalize(bulletDir);
        }
        else
        {
            bulletDir.Set(1, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Playerdata.transform.position, transform.position) > range)//100 is arbitrary, just has to be offscreen
        {
            Destroy(gameObject);
        }
        transform.position = transform.position + (bulletDir * speed) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")//will need to be an enemy tag if multiple enemies
        {
            collision.gameObject.SendMessage("damageApply", attack.SaveToString());
            pierce -= 1;
            if (pierce <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}