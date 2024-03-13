using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseScript : MonoBehaviour
{

    public Vector3 playerDir;
    public Vector3 previousDir;
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
    private float frameRate = 0.5f;
    private SpriteRenderer spriteRenderer;
    private Sprite[] newSprites = new Sprite[4];

    private float XPBonus = 1f;
    private GameObject spawner;
    private GameObject deathscreen;

    private bool[] passives = new bool[8];
    private float[,] passiveFx = new float[8,4] { { 3f, 0f, 0f, 0f }, { 0f, 0.2f, 0f, 0f }, { 0f, 0f, 0.2f, 0f }, { 0f, -0.1f, 0.5f, 0f }, { 0f, 0f, 0f, 0.1f }, { -1f, 0.2f, 0f, 0f }, { 5f, -.1f, 0f, 0f }, { 0f, 0f, -0.1f, 0.25f } };
    // Start is called before the first frame update
    void Start()
    {
        previousDir = new Vector3(1f, 0f, 0f);
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

        //guns[0].SetActive(true);
        //timers[0].have = true;
        timers[0].cooldown = 0.5f;
        timers[1].cooldown = 1f;
        timers[2].cooldown = 1f;
        timers[3].cooldown = 1.5f;
        timers[4].cooldown = 1.5f;
        timers[5].cooldown = 3f;
        timers[6].cooldown = 3f;

        guns[0].SetActive(true);
        timers[0].have = true;
        guns[1].SetActive(true);
        timers[1].have = true;
        guns[2].SetActive(true);
        timers[2].have = true;
        guns[3].SetActive(true);
        timers[3].have = true;
        guns[4].SetActive(true);
        timers[4].have = true;
        guns[5].SetActive(true);
        timers[5].have = true;
        guns[6].SetActive(true);
        timers[6].have = true;
        guns[7].SetActive(true);
        applyPassive(0);
        applyPassive(1);
        applyPassive(2);
        applyPassive(3);
        applyPassive(4);
        applyPassive(5);
        applyPassive(6);
        applyPassive(7);

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
                previousDir = playerDir;
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
            xpgoal += 1;//--------------------------------------------------------------
            levelup();
        }
    }

    public void levelup()
    {
        guns[0].SendMessage("Upgrade");
        guns[1].SendMessage("Upgrade");
        guns[2].SendMessage("Upgrade");
        guns[3].SendMessage("Upgrade");
        guns[4].SendMessage("Upgrade");
        guns[5].SendMessage("Upgrade");
        guns[6].SendMessage("Upgrade");
        guns[7].SendMessage("Upgrade");
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
