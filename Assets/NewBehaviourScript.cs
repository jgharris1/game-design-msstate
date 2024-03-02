using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWeaponBehaviour : MonoBehaviour
{
    public GameObject Playerdata;
    // Start is called before the first frame update
    void Start()
    {
        Playerdata = GameObject.FindWithTag("Player");
    }

    void attack()
    {
        //player has sent an attack 
        //command do whatever spawning 
        //you need here
    }

    void upgrade()
    {
        //do whatever data manipulation 
        //an upgrade needs
        //if an upgrade changes fireRate 
        //do Playerdata.changeFR(int weapon_id, float new_fireRate)
    }
}
