using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseScript : MonoBehaviour
{

    public Vector3 playerDir;
    public int health;
    public float entitySpeed;
    public GameObject bulletPrefab;
    GameObject bullet;
    public damageData attack;
    public bool dead;
    public float experience = 10.0f;
    public float xpgoal = 0.0f;

    private GameObject[] guns = new GameObject[8];
    public timerdata[] timers = new timerdata[8];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            timers[i] = new timerdata();
            timers[i].cooldown = 0.0f;
            timers[i].timer = 0.0f; 
            timers[i].have = false;
        }
        //for (int i = 0; i < 8; i++)
        //{
            //guns[i] = FindGameObjectWithTag("gun" + i)
        //}
        playerDir = new Vector3(0.0f, 0.0f, 0.0f);
        GetComponent<Rigidbody2D>().freezeRotation = true;
        timers[2].cooldown = 1.0f;
        timers[2].have = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            updateTimers();
            playerDir.Set(0, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                playerDir.Set(playerDir.x, playerDir.y + 1, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                playerDir.Set(playerDir.x - 1, playerDir.y, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerDir.Set(playerDir.x, playerDir.y - 1, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                playerDir.Set(playerDir.x + 1, playerDir.y, 0);
            }
            //Selfdata.targetPos.Set(transform.position.x + playerDir.x, transform.position.y + playerDir.y, 0);
            if ((Mathf.Abs(playerDir.x) + Mathf.Abs(playerDir.y)) != 0)
            {
                playerDir = Vector3.Normalize(playerDir);
                transform.position = transform.position + (playerDir * entitySpeed) * Time.deltaTime;
            }
        }
    }

    public void damageApply(string attackStr)//, int statusId = 0, int statusLevel = 0, float duration = 0)
    {
        attack = JsonUtility.FromJson<damageData>(attackStr);
        health -= attack.damage;
        if (health <= 0)
        {
            dead = true;
            GameObject.FindGameObjectWithTag("Spawner").SetActive(false);
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy.SetActive(false);
            }
            foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("Bullet"))
            {
                bullet.SetActive(false);
            }
        }
    }

    public void addEXP(float xp)
    {
        experience += xp;
        if (experience > xpgoal)
        {
            experience -= xpgoal;
            xpgoal += 10;
            levelup();
        }
    }

    public void levelup()
    {
        //open level up menu
        //make choice
        //string guntag = "gun" + weaponID;
        //GameObject choice = FindGameObjectWithTag(guntag);
        //choise.upgrade();
    }

    public void changeFR(int weaponID, float new_fireRate)
    {
        timers[weaponID].cooldown = new_fireRate;
    }

    private void updateTimers()
    {
        for (int i = 0; i < 8; i++)
        {
            if (timers[i].have)
            {
                timers[i].timer += Time.deltaTime;
                if (timers[i].timer >= timers[i].cooldown)
                {
                    timers[i].timer -= timers[i].cooldown;
                    guns[i].SendMessage("attack");
                }
            }
        }
    }
}
