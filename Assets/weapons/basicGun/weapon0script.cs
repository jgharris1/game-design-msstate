using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon0script : MonoBehaviour
{    
    public GameObject bulletPrefab;
    public int bulletCount;
    private float timer;
    GameObject bullet0;
    GameObject bullet1;
    GameObject bullet2;
    // Start is called before the first frame update
    void Attack()
    {
        bullet0 = Instantiate(bulletPrefab, transform.parent.position, transform.parent.rotation);

        if (bulletCount >= 2)
        {
            timer = Time.time;
            while ((Time.time - timer) < .05) { }
            bullet1 = Instantiate(bulletPrefab, transform.parent.position, transform.parent.rotation);
        }

        if (bulletCount >= 3)
        {
            timer = Time.time;
            while ((Time.time - timer) < .05) { }
            bullet2 = Instantiate(bulletPrefab, transform.parent.position, transform.parent.rotation);
        }
    }
    public void setBulletCount(int countIn)//for use in bullet
    {
        bulletCount = countIn;
    }
}
