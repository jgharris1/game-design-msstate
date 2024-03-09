using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon0script : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    GameObject bullet;
    // Start is called before the first frame update
    void Attack()
    {
        bullet = Instantiate(bulletPrefab, transform.parent.position, transform.parent.rotation);
    }
}
