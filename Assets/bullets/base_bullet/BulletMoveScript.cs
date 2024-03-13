using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveScript : MonoBehaviour
{
    //public entitybasebehavior Selfdata;
    private Vector3 bulletDir;
    private GameObject Playerdata;
    private float speed = 5;
    private float range = 20;
    private float size = 1f;
    private damageData attack = new damageData();
    private int statusId = 0;
    private int statusLevel = 0;
    private float statusDur = 0;
    private int style = 0;
    private float badgeoffset = 0;
    private int badgecnt = 1;
    private Vector3 Target;
    private float DelTime = 0f;
    private bool used;
    private Vector3 scale;
    private SpriteRenderer sprite;
    private float timer;
    private float percentage;
    private float spawnTime = .3f;
    public AudioSource boom;
    public AudioSource shift;
    // Start is called before the first frame update
    void Start()
    {
        attack.statusId = statusId;
        attack.statusLevel = statusLevel;
        attack.statusDur = statusDur;
        Playerdata = GameObject.FindWithTag("Player");
        if (style == 0)
        {
            Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            bulletDir.Set(mPosition.x - transform.position.x, mPosition.y - transform.position.y, 0);
            if ((Mathf.Abs(bulletDir.x) + Mathf.Abs(bulletDir.y)) != 0)
            {
                bulletDir = Vector3.Normalize(bulletDir);
            }
            else
            {
                bulletDir.Set(1, 0, 0);
            }
            transform.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
        }
        else if (style == 1)
        {
            bulletDir = Playerdata.GetComponent<PlayerBaseScript>().previousDir;
            bulletDir = Quaternion.Euler(0f, 0f, Random.Range(-15f, 15f)) * Vector3.Normalize(bulletDir);
            transform.GetComponent<SpriteRenderer>().material.color = new Color(0.25f, 0.25f, 0.25f, 1f);
        }
        else if (style == 2)
        {
            bulletDir = Playerdata.GetComponent<PlayerBaseScript>().previousDir;
            bulletDir = Quaternion.Euler(0f, 0f, (float)(((float)360 / (float)badgecnt) * (float)badgeoffset)) * Vector3.Normalize(bulletDir);
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("weapons/badge");
        }
        else if (style == 3)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (0 < enemies.Length)
            {
                int i = 0;
                int j = 0;
                float k = 1000f;
                float h = 1000f;
                foreach (GameObject enemy in enemies)
                {
                    k = Vector3.Distance(enemy.transform.position, transform.position);
                    if (k < h)
                    {
                        j = i;
                        h = k;
                    }
                    i += 1;
                }
                Target = new Vector3(0f, 0f, 0f);
                Target = GameObject.FindGameObjectsWithTag("Enemy")[j].transform.position;
                Target += GameObject.FindGameObjectsWithTag("Enemy")[j].GetComponent<enemybasescript>().targetDif * (Mathf.Sqrt(2 * (5f - Mathf.Min(4.5f, (Target.y - Playerdata.transform.position.y))) / 9.81f) + (Mathf.Sqrt(2 * 9.81f * 5f) / 9.81f));
                Vector3 VelVec = new Vector3((Target.x - Playerdata.transform.position.x) / ((Mathf.Sqrt(2 * (5f - Mathf.Min(4.5f, (Target.y - Playerdata.transform.position.y))) / 9.81f) + (Mathf.Sqrt(2 * 9.81f * 5f) / 9.81f))), 9.9f, 0f);
                GetComponent<Rigidbody2D>().velocity = VelVec;
                GetComponent<Rigidbody2D>().gravityScale = 1;
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("weapons/dynamite");
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (style == 4)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (0 < enemies.Length)
            {
                Vector3 VelVec = new Vector3(Random.Range(-3f, 3f), 9.9f, 0);
                GetComponent<Rigidbody2D>().velocity = VelVec;
                GetComponent<Rigidbody2D>().gravityScale = 1;
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("weapons/gavel");
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (style == 5)
        {
            Vector3 offset = new Vector3(15f, Random.Range(-4.5f, 4.5f), 0);
            bool left = (Random.value > 0.5f);
            if (left)
            {
                offset.x = -offset.x;
                transform.Rotate(0f, 0f, 180f);
                bulletDir.Set(1f, 0f, 0f);
            }
            else
            { 
                bulletDir.Set(-1f, 0f, 0f);
            }
            transform.position += offset;
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("weapons/worm_friend");
            GetComponent<CapsuleCollider2D>().enabled = true;
            shift.Play();
        }
        else if (style == 6)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (0 < enemies.Length)
            {
                int i = 0;
                int j = 0;
                float k = 1000f;
                float h = 1000f;
                foreach (GameObject enemy in enemies)
                {
                    k = Vector3.Distance(enemy.transform.position, transform.position);
                    if (k < h)
                    {
                        j = i;
                        h = k;
                    }
                    i += 1;
                }
                GameObject.FindGameObjectsWithTag("Enemy")[j].SendMessage("damageApply", attack.SaveToString());
                transform.position = GameObject.FindGameObjectsWithTag("Enemy")[j].transform.position;
                scale = new Vector3(0f, 0f, 0f);
                sprite = GetComponent<SpriteRenderer>();
                sprite.material.color = new Color(0f, 1f, 0f, 1f);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Playerdata.transform.position, transform.position) > range)//100 is arbitrary, just has to be offscreen
        {
            Destroy(gameObject);
        }
        if (style != 3 && style != 4)
        { 
            transform.position = transform.position + (bulletDir * speed) * Time.deltaTime; 
        }
        if (style == 2 || style == 3 || style == 4)
        {
            transform.Rotate(0, 0, 6.0f * 100 * Time.deltaTime);
        }
        if (style == 3)
        {
            if (Vector3.Distance(Target, transform.position) < .2 && !used)
            {
                Explode();
            }
            if (DelTime != 0f && Time.time > DelTime)
            {
                Destroy(gameObject);
            }
        }
        if (style == 6)
        {
            timer += Time.deltaTime;
            percentage = timer / spawnTime;
            sprite.material.color = new Color(0f, 1f, 0f, 1 - percentage);
            scale.Set(percentage * 5f, percentage * 5f, 0f);
            transform.localScale = scale;
            if (percentage > 1)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (style != 3 && style != 6)
        {
            if (collision.gameObject.tag == "Enemy")//will need to be an enemy tag if multiple enemies
            {
                collision.gameObject.SendMessage("damageApply", attack.SaveToString());
                if (style != 5)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void setData(int DMG, float SPD, float SIZ, int type, float badge = 0f)
    {
        attack.damage = DMG;
        speed = SPD;
        transform.localScale = new Vector3(SIZ, SIZ, 0f);
        size = SIZ;
        style = type;
        badgecnt = (int)badge;
        badgeoffset = ((badge % 1) * 10);
    }

    private void Explode()
    {
        boom.Play();
        used = true;
        transform.localScale = new Vector3(size * 5, size * 5, 0f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("weapons/badge");
        GetComponent<SpriteRenderer>().material.color = new Color(1f, 0f, 0f, 1f);
        transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f, 0f);
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("weapons/badge");
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 0f, 1f);
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
        DelTime = Time.time + .2f;
        float dist = 0;
        Vector3 dif = new Vector3(0f, 0f, 0f); 
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            dist = Vector3.Distance(enemy.transform.position, Target);
            if (dist < size)
            {
                dif = enemy.transform.position - Target;
                enemy.GetComponent<Rigidbody2D>().velocity = dif * (2 - dist) * 20;
            }
            if (dist < size * 2)
            {
                enemy.gameObject.SendMessage("damageApply", attack.SaveToString());
            }
        }
    }
}
