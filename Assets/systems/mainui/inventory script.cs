using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryscript : MonoBehaviour
{
    private bool[,] items = new bool[2, 8] {{false ,false, false, false, false, false, false, false}, {false ,false, false, false, false, false, false, false}};
    public Image[] weapons = new Image[6];
    public Image[] passives = new Image[6];
    public Sprite[] weaponsspr = new Sprite[8];
    public Sprite[] passivesspr = new Sprite[8];
    private int weaponcnt = 0;
    private int passivecnt = 0;


    public void addItem(int id, int weapon)
    {
        if (!items[weapon, id])
        {
            items[weapon, id] = true;
            if (weapon == 1)
            {
                weapons[weaponcnt].sprite = weaponsspr[id];
                weapons[weaponcnt].color = new Color(1f, 1f, 1f, 1f);
                weaponcnt += 1;
            }
            else
            {
                passives[passivecnt].sprite = passivesspr[id];
                passives[passivecnt].color = new Color(1f, 1f, 1f, 1f);
                passivecnt += 1;
            }
        }
    }
}
