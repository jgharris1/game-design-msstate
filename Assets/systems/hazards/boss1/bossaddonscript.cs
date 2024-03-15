using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossaddonscript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] fireSprite = new Sprite[2];
    public bool fireSpriteExists;
    private float fireTimer;
    private float burstTimer;
    private float fireRate = 5f;
    public GameObject hazardPrefab;
    private int burstcnt;
    private int firePer = 1;
    GameObject hazard;
    public enemybasescript selfData;
    private int health;
    private int healthGoal;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        burstcnt = firePer;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        health = selfData.health;
        healthGoal = health - 90;
    }

    // Update is called once per frame
    void Update()
    {
        health = selfData.health;
        if (health <= healthGoal)
        {
            healthGoal -= 70;
            firePer += 1;
            burstcnt += 1;
            if (fireSpriteExists)
            {
                spriteRenderer.sprite = fireSprite[0];

            }
        }
        if (fireTimer > fireRate)
        {
            if (burstcnt == firePer && id == 1)
            {
                GetComponent<AudioSource>().Play();
            }
            if (burstcnt == 0)
            {
                fireTimer = 0f;
                burstcnt = firePer;
            }
            else
            {
                if (burstTimer > .3f)
                {
                    if (fireSpriteExists)
                    {
                        spriteRenderer.sprite = fireSprite[1];
                    }
                    burstTimer = 0f;
                    Instantiate(hazardPrefab, transform.position, transform.rotation);
                    burstcnt -= 1;
                }
                else
                {
                    burstTimer += Time.deltaTime;
                }
            }
        }
        else
        {
            fireTimer += Time.deltaTime;
        }
    }
}
