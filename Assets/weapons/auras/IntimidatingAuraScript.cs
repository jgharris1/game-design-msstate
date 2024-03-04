using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntimidatingAuraScript : MonoBehaviour
{
    private float cooldown = 0.2f;
    private Dictionary<Collider2D, float> timeTable = new Dictionary<Collider2D, float>();
    
    public damageData attack;
    public string attackmessage;
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
        attackmessage = attack.SaveToString();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        float timer;
        if(!timeTable.TryGetValue(collision, out timer))
        {
            return;
        }
        if (Time.time > timer)
        {
            timeTable[collision] = Time.time + cooldown;
            collision.gameObject.SendMessage("damageApply", attackmessage);
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
}
