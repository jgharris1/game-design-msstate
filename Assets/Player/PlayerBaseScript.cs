using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseScript : MonoBehaviour
{

    public Vector3 playerDir;
    public Vector3 previousDir;
    private int health;
    private int healthMax = 3;
    private float entitySpeed = 3;
    private float entitySpeedBackup;
    private damageData attack;
    private bool dead;
    private float experience = 0f;
    private float xpgoal = 10f;
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

    public HealthSystem bars;

    public inventoryscript inven;

    public levelscript leveling;

    private bool[] passives = new bool[8];
    private float[,] passiveFx = new float[8,4] { { 3f, 0f, 0f, 0f }, { 0f, 0.2f, 0f, 0f }, { 0f, 0f, 0.2f, 0f }, { 0f, -0.1f, 0.5f, 0f }, { 0f, 0f, 0f, 0.1f }, { -1f, 0.2f, 0f, 0f }, { 5f, -.1f, 0f, 0f }, { 0f, 0f, -0.1f, 0.25f } };

    public AudioSource levelAudio;
    // Start is called before the first frame update
    void Start()
    {
        bars.SetMaxHealth(healthMax);
        bars.SetHealth(healthMax);
        bars.SetMaxMana(xpgoal);
        bars.SetMana(experience);
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

        timers[0].cooldown = 0.5f;
        timers[1].cooldown = 1f;
        timers[2].cooldown = 1f;
        timers[3].cooldown = 1.5f;
        timers[4].cooldown = 1.5f;
        timers[5].cooldown = 3f;
        timers[6].cooldown = 3f;

        guns[0].SetActive(true);
        timers[0].have = true;

        inven.addItem(0, 1);

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
        bars.SetHealth(health);
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
            xpgoal *= 1.5;//--------------------------------------------------------------
            bars.SetMaxMana(xpgoal);
            bars.SetMana(experience);
            levelAudio.Play();
            levelup();
        }
        else 
        {
            bars.SetMana(experience);
        }
    }

    public void levelup()
    {
        leveling.load();
    }

    public void receivelevelup(int id, int weapon)
    {
        if (weapon == 1)
        {
            inven.addItem(id, weapon);
            guns[id].SetActive(true);
            if (id != 7)
            {
                timers[id].have = true;
            }
            guns[id].SendMessage("Upgrade");
        }
        else
        {
            inven.addItem(id, weapon);
            applyPassive(id);
        }
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
        bars.SetHealth(health);
        bars.SetMaxHealth(healthMax);
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
        Destroy(GameObject.Find("pause(Clone)"));
        deathscreen.SetActive(true);
    }
}
