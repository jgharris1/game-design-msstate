using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntimidatingAuraScript : MonoBehaviour
{
    private float cooldown = 0.2f;
    private Dictionary<Collider2D, float> timeTable = new Dictionary<Collider2D, float>();

    private damageData attack;
    private int damage = 2;
    private int statusId = 0;
    private int statusLevel = 0;
    private float statusDur = 0;
    private int level = 0;
    public Light halo;
    // Start is called before the first frame update
    void Start()
    {
        attack = new damageData();
        attack.damage = damage;
        attack.statusId = statusId;
        attack.statusLevel = statusLevel;
        attack.statusDur = statusDur;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        float timer;
        if (!timeTable.TryGetValue(collision, out timer))
        {
            return;
        }
        if (Time.time > timer)
        {
            timeTable[collision] = Time.time + cooldown;
            collision.gameObject.SendMessage("damageApply", attack.SaveToString());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            timeTable[collision] = Mathf.NegativeInfinity;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (timeTable.ContainsKey(collision))
        {
            timeTable.Remove(collision);
        }
    }

    void Upgrade()
    {
        level += 1;
        switch (level)
        {
            case 2:
                transform.localScale = new Vector3(3.75f, 3.75f, 0f);
                halo.range = 5f;
                break;
            case 3:
                damage = 3;
                break;
            case 4:
                damage = 5;
                break;
            case 5:
                transform.localScale = new Vector3(4.35f, 4.35f, 0f);
                halo.range = 5.8f;
                damage = 6;
                break;
            case 6:
                cooldown = 0.15f;
                break;
            case 7:
                damage = 8;
                break;
            case 8:
                transform.localScale = new Vector3(4.95f, 4.95f, 0f);
                halo.range = 6.6f;
                break;
            case 9:
                damage = 11;
                break;
        }
    }
}
