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
    public float immuneFrame = 0;
    private damageData attackin;
    private damageData attackout;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        attackout = new damageData();
        attackout.damage = damage;
        attackout.statusId = 0;
        attackout.statusLevel = 0;
        attackout.statusDur = 0;
        Playerdata = GameObject.FindWithTag("Player");
        targetDif = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        immuneFrame -= Time.deltaTime;
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
    public void damageApply(string attackStr)//, int statusId = 0, int statusLevel = 0, float duration = 0)
    {
        attackin = JsonUtility.FromJson<damageData>(attackStr);
        health -= attackin.damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void setData(string data)
    {
        entitySpeed = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (immuneFrame <= 0)
        {
            if (collision.gameObject.tag == "Player")//will need to be an enemy tag if multiple enemies
            {
                collision.gameObject.SendMessage("damageApply", attackout.SaveToString());
                gameObject.SendMessage("damageApply", attackout.SaveToString());
            }
        }
    }
}