using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon0script : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    GameObject bullet;
    public int level;
    // Start is called before the first frame update
    void Attack()
    {
        bullet = Instantiate(bulletPrefab, transform.parent.position, transform.parent.rotation);
    }

    void Upgrade()
    {
        level += 1;
        if (level == 1)
        {
            //setup heres where you would read 
            //shop upgrades that are relavent 
            //and change variables
        }
        if (level == 2)
        {
            //first level up
        }
        //do levelups here
    }
}
