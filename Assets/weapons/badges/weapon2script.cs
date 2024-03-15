using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon2script : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject bullet;
    private PlayerBaseScript playerData;
    private int level = 0;
    private int damage = 8;
    private float speed = 4f;
    private float size = 1f;
    private int burst = 1;
    private float badgemsg = 1f;
    private int ID = 2;
    // Start is called before the first frame update
    void Start()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBaseScript>();
    }

    void Attack()
    {
        GetComponent<AudioSource>().Play();
        for (int i = 0; i < burst; i++)
        {
            badgemsg = (float)burst + (float)i * 0.1f;
            bullet = Instantiate(bulletPrefab, transform.parent.position, transform.parent.rotation);
            bullet.GetComponent<BulletMoveScript>().setData(damage, speed, size, 2, badgemsg);
        }
    }

    void Upgrade()
    {
        level += 1;
        switch (level)
        {
            case 2:
                size = 1.2f;
                speed = 4.4f;
                break;
            case 3:
                burst = 2;
                break;
            case 4:
                playerData.changeFR(ID, .8f);
                break;
            case 5:
                size = 1.3f;
                break;
            case 6:
                burst = 3;
                break;
            case 7:
                burst = 4;
                speed = 5f;
                break;
            case 8:
                burst = 5;
                damage = 13;
                break;
            case 9:
                speed = 5.8f;
                size = 1.5f;
                break;
        }
    }
}
