using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon6script : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject bullet;
    private PlayerBaseScript playerData;
    public int level = 1;
    private int damage = 5;
    private float speed = 0f;
    private float size = 5f;
    private int ID = 6;
    // Start is called before the first frame update

    void Start()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBaseScript>();
    }


    void Attack()
    {
        bullet = Instantiate(bulletPrefab, transform.parent.position, transform.parent.rotation);
        bullet.GetComponent<BulletMoveScript>().setData(damage, speed, size, 6);
    }

    void Upgrade()
    {
        level += 1;
        switch (level)
        {
            case 2:
                damage = 10;
                break;
            case 3:
                playerData.changeFR(ID, 2.5f);
                break;
            case 4:
                damage = 15;
                break;
            case 5:
                playerData.changeFR(ID, 2f);
                break;
            case 6:
                damage = 20;
                break;
            case 7:
                playerData.changeFR(ID, 1.5f);
                break;
            case 8:
                damage = 25;
                break;
            case 9:
                playerData.changeFR(ID, 1f);
                break;
        }
    }
}
