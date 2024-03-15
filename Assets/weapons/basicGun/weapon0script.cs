using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon0script : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    GameObject bullet;
    private PlayerBaseScript playerData;
    private int level = 1;
    private int damage = 5;
    private float fireRate = .5f;
    private int ID = 0;
    private float speed = 5;
    private float size = 1f;
    public int burstsize = 1;
    public int burstleft = 1;
    public float bursttimer = 0f;
    private float burstRate = 0.05f;
    public AudioSource Audio;
    // Start is called before the first frame update
    void Start()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBaseScript>();
    }

    void Update()
    {
        if (burstleft != 0)
        {
            bursttimer += Time.deltaTime;
            if (bursttimer > burstRate)
            {
                bullet = Instantiate(bulletPrefab, transform.parent.position, transform.parent.rotation);
                bullet.GetComponent<BulletMoveScript>().setData(damage, speed, size, 0);
                burstleft -= 1;
                bursttimer = 0f; 
            }
        }
    }

    void Attack()
    {
        bullet = Instantiate(bulletPrefab, transform.parent.position, transform.parent.rotation);
        bullet.GetComponent<BulletMoveScript>().setData(damage, speed, size, 0);
        burstleft = burstsize - 1;
        bursttimer = 0f; 
        Audio.Play();
    }

    void Upgrade()
    {
        level += 1;
        switch (level)
        {
            case 2:
                damage = 7; 
                break;
            case 3:
                damage = 10;
                speed = 5.25f;
                break;
            case 4:
                burstsize = 2;
                break;
            case 5:
                damage = 15;
                break;
            case 6:
                size = 1.5f;
                break;
            case 7:
                fireRate = 0.4f;
                playerData.changeFR(ID, fireRate);
                break;
            case 8:
                burstsize = 3;
                break;
            case 9:
                damage = 25;
                break;
        }
    }
}
