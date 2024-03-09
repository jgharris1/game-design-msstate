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
    public int level;
    public int damage;
    public int statusId;
    public int statusLevel;
    public float statusDur;
    public GameObject player;
    public GameObject gun;

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

    void Upgrade()
    {
        level += 1;
        switch (level)
        {
            case 1:
                damage += 2;
                break;
            case 2:
                damage += 3;
                speed += 0.1f;
                break;
            case 3:
                gun.GetComponent<weapon0script>().setBulletCount(2);
                break;
            case 4:
                damage += 5;
                //crit chance increase
                break;
            case 5:
                //size increase;
                break;
            case 6:
                player.GetComponent<PlayerBaseScript>().changeFR(0, 400);
                break;
            case 7:
                gun.GetComponent<weapon0script>().setBulletCount(3);
                break;
            case 8:
                damage += 10;
                break;
            case 9://infinite upgrade
                damage += 5;
                level -= 1;
                break;
            default:
                break;//shouldn't happen; good practice
        }
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
