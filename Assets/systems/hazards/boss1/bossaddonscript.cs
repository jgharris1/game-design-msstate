using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossaddonscript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] fireSprite = new Sprite[2];
    public bool fireSpriteExists;
    public float fireTimer;
    public float burstTimer;
    public float fireRate;
    public GameObject hazardPrefab;
    public int burstcnt;
    public int firePer = 1;
    GameObject hazard;
    public enemybasescript selfData;
    public int health;
    public int healthGoal;
    // Start is called before the first frame update
    void Start()
    {
        burstcnt = firePer;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        health = selfData.health;
        healthGoal = health - 70;
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
