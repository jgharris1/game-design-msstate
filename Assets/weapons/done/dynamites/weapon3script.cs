using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon3script : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject bullet;
    private PlayerBaseScript playerData;
    public int level = 1;
    private int damage = 10;
    private float speed = 1f;
    private float size = 1f;
    private int ID = 3;
    // Start is called before the first frame update

    void Start()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBaseScript>();
    }

    void Attack()
    {
        bullet = Instantiate(bulletPrefab, transform.parent.position, transform.parent.rotation);
        bullet.GetComponent<BulletMoveScript>().setData(damage, speed, size, 3);
    }

    void Upgrade()
    {
        level += 1;
        switch (level)
        {
            case 2:
                damage = 20;
                break; 
            case 3:
                size = 1.1f;
                break;
            case 4:
                damage = 30;
                break;
            case 5:
                size = 1.2f;
                break;
            case 6:
                damage = 40;
                break;
            case 7:
                size = 1.3f;
                break;
            case 8:
                damage = 50;
                break;
            case 9:
                playerData.changeFR(ID, 1f);
                break;
        }
    }
}
