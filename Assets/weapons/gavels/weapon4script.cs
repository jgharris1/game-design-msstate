using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon4script : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject bullet;
    private PlayerBaseScript playerData;
    public int level = 1;
    private int damage = 10;
    private float speed = 1f;
    private float size = 1f;
    private int burst = 2;
    private int ID = 4;
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
            bullet = Instantiate(bulletPrefab, transform.parent.position, transform.parent.rotation);
            bullet.GetComponent<BulletMoveScript>().setData(damage, speed, size, 4);
        }
    }

    void Upgrade()
    {
        level += 1;
        switch (level)
        {
            case 2:
                size = 1.2f;
                break;
            case 3:
                burst = 3;
                break;
            case 4:
                playerData.changeFR(ID, 1.25f);
                break;
            case 5:
                size = 1.4f;
                damage = 15;
                break;
            case 6:
                burst = 4;
                break;
            case 7:
                burst = 5;
                damage = 20;
                break;
            case 8:
                playerData.changeFR(ID, 1f);
                break;
            case 9:
                playerData.changeFR(ID, 0.75f);
                damage = 25;
                break;
        }
    }
}
