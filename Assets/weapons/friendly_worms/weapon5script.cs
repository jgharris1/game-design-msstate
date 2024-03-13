using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon5script : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject bullet;
    private PlayerBaseScript playerData;
    public int level = 1;
    private int damage = 5;
    private float speed = 8f;
    private float size = 3f;
    private int ID = 5;
    // Start is called before the first frame update

    void Start()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBaseScript>();
    }

    void Attack()
    {
        bullet = Instantiate(bulletPrefab, transform.parent.position, transform.parent.rotation);
        bullet.GetComponent<BulletMoveScript>().setData(damage, speed, size, 5);
    }

    void Upgrade()
    {
        level += 1;
        switch (level)
        {
            case 2:
                size = 3.3f;
                break;
            case 3:
                damage = 10;
                break;
            case 4:
                size = 3.6f;
                playerData.changeFR(ID, 2.5f);
                break;
            case 5:
                size = 3.9f;
                break;
            case 6:
                damage = 15;
                break;
            case 7:
                damage = 20;
                break;
            case 8:
                size = 4.2f;
                break;
            case 9:
                playerData.changeFR(ID, 2f);
                break;
        }
    }
}
