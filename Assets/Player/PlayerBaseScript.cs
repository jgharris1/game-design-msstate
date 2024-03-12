using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseScript : MonoBehaviour
{

    public Vector3 playerDir;
    public int health;
    public int healthMax = 3;
    private float entitySpeed = 3;
    private float entitySpeedBackup;
    private damageData attack;
    private bool dead;
    public float experience = 10.0f;
    public float xpgoal = 0.0f;
    private bool mad_howl_effect;
    private float mad_howl_timer;

    private GameObject[] guns = new GameObject[8];
    private timerdata[] timers = new timerdata[7];
    
    private Vector3 scale;
    private int Frame;
    private float frameTimer;
    public float frameRate;
    private SpriteRenderer spriteRenderer;
    private Sprite[] newSprites = new Sprite[4];
    public float speedshow;

    public float XPBonus = 1f;
    public GameObject spawner;
    public GameObject deathscreen;

    public bool[] passives = new bool[8];
    public float[,] passiveFx = new float[8,4] { { 3f, 0f, 0f, 0f }, { 0f, 0.2f, 0f, 0f }, { 0f, 0f, 0.2f, 0f }, { 0f, -0.1f, 0.5f, 0f }, { 0f, 0f, 0f, 0.1f }, { -1f, 0.2f, 0f, 0f }, { 5f, -.1f, 0f, 0f }, { 0f, 0f, -0.1f, 0.25f } };
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        deathscreen = GameObject.FindGameObjectsWithTag("deathscreen")[GameObject.FindGameObjectsWithTag("deathscreen").Length-1];
        deathscreen.SetActive(false);
        health = healthMax;
        entitySpeedBackup = entitySpeed;
        for (int i = 0; i < 7; i++)
        {
            timers[i] = new timerdata();
            timers[i].cooldown = 0.0f;
            timers[i].timer = 0.0f; 
            timers[i].have = false;
        }
        for (int i = 0; i < 8; i++)
        {
            guns[i] = GameObject.FindGameObjectWithTag("gun" + i);
            guns[i].SetActive(false);
        }

        //delete later vv
        timers[0].have = true;
        timers[0].cooldown = 0.5f;
        guns[0].SetActive(true);
        guns[7].SetActive(true);
        // delete later^^
        playerDir = new Vector3(0.0f, 0.0f, 0.0f);
        GetComponent<Rigidbody2D>().freezeRotation = true;
        scale = transform.localScale;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        string linkBase = "player/frame-";
        for (int i = 0; i < 4; i++)
        {
            newSprites[i] = Resources.Load<Sprite>(linkBase + (i + 1));
        }
        applyPassive(1);
        applyPassive(1);
    }

    // Update is called once per frame
    void Update()
    {
        speedshow = entitySpeed;
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
            if (mad_howl_effect)
            {
                mad_howl_timer -= Time.deltaTime;
                if (mad_howl_timer < 0)
                {
                    mad_howl_effect = false;
                    entitySpeed = entitySpeedBackup;
                }
            }
            if ((Mathf.Abs(playerDir.x) + Mathf.Abs(playerDir.y)) != 0)
            {
                if (frameTimer > frameRate)
                {
                    frameTimer = 0f;
                    Frame += 1;
                    Frame %= 2;
                    spriteRenderer.sprite = newSprites[Frame];
                }
                frameTimer += Time.deltaTime;
                
                if (playerDir.x < 0)
                {
                    scale.x = -3;
                }
                else
                {
                    scale.x = 3;
                }
                transform.localScale = scale;
                playerDir = Vector3.Normalize(playerDir);
                transform.position = transform.position + (playerDir * entitySpeed) * Time.deltaTime;
            }
        }
        else
        {
            playerDir.Set(-1f, 0f, 0f);
            transform.position = transform.position + (playerDir * entitySpeed) * Time.deltaTime;
        }
    }

    public void damageApply(string attackStr)//, int statusId = 0, int statusLevel = 0, float duration = 0)
    {
        attack = JsonUtility.FromJson<damageData>(attackStr);
        health -= attack.damage;
        if (health <= 0)
        {
            InstDeath();
        }
    }

    public void addEXP(float xp)
    {
        experience += (int)(xp * XPBonus);
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
        for (int i = 0; i < 7; i++)
        {
            if (timers[i].have)
            {
                timers[i].timer += Time.deltaTime;
                if (timers[i].timer >= timers[i].cooldown)
                {
                    timers[i].timer -= timers[i].cooldown;
                    guns[i].SendMessage("Attack");
                }
            }
        }
    }

    public void mad_howl()
    {
        mad_howl_effect = true;
        mad_howl_timer = 5.0f;
        entitySpeed = entitySpeed * 0.95f;
    }

    public void applyPassive(int ID)
    {
        health += (int)passiveFx[ID, 0];
        healthMax += (int)passiveFx[ID, 0];
        entitySpeed += passiveFx[ID, 1];
        entitySpeedBackup += passiveFx[ID, 1];
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy.SendMessage("setDMGBonus", passiveFx[ID, 2]);
        }
        spawner.SendMessage("setDMGBonus", passiveFx[ID, 2]);
        XPBonus += passiveFx[ID, 3];
        if (health <= 0)
        {
            InstDeath();
        }
    }

    public void InstDeath()
    {
        dead = true;
        gameObject.GetComponent<Collider2D>().enabled = false;
        GameObject.FindGameObjectWithTag("Spawner").SetActive(false);
        spriteRenderer.sprite = newSprites[3];
        transform.Rotate(0f, 0f, 90f, Space.Self);
        scale.x = 3;
        transform.localScale = scale;
        Camera.main.gameObject.transform.Rotate(0f, 0f, -90f, Space.Self);
        deathscreen.SetActive(true);
    }
}
