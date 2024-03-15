using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon1script : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject bullet;
    private PlayerBaseScript playerData;
    private int level = 0;
    private int damage = 5;
    private float speed = 5;
    private float size = .6f;
    private int burst = 5;
    public AudioSource Audio;
    // Start is called before the first frame update

    void Attack()
    {
        Audio.Play();
        for (int i = 0; i < burst; i++)
        {
            bullet = Instantiate(bulletPrefab, transform.parent.position, transform.parent.rotation);
            bullet.GetComponent<BulletMoveScript>().setData(damage, speed, size, 1);
        }
    }

    void Upgrade()
    {
        level += 1;
        switch (level)
        {
            case 2:
                burst = 6;
                break;
            case 3:
                burst = 7;
                break;
            case 4:
                burst = 8;
                break;
            case 5:
                burst = 9;
                break;
            case 6:
                burst = 10;
                break;
            case 7:
                burst = 11;
                break;
            case 8:
                burst = 12;
                break;
            case 9:
                burst = 13;
                break;
        }
    }
}
