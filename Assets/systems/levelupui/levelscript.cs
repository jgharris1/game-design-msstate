using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelscript : MonoBehaviour
{
    private string[,,,] leveldetails = new string[2, 8, 9, 3]
    {
        {
            {
                {"Healthy", "+3 HP", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""}
            },
            {
                {"Swift Steps", " +0.2 Speed", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""}
            },
            {
                {"Empowered", " +20% Damage", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""}
            },
            {
                {"Meticulous", "+50% Damage", "-0.1 Speed"},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""}
            },
            {
                {"Lucky", "+10% EXP", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""}
            },
            {
                {"Reckless Abandon", "+0.2 Speed", " -1 HP"},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""}
            },
            {
                {"Dessert Bastion", "+5 HP", " -0.1 Speed"},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""}
            },
            {
                {"Gambling", "+25% EXP", "-10% Damage"},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""},
                {"", "", ""}
            }
        },
        {
            {
                {"Revolver", "", ""},
                {"Revolver", "+2 Damage", ""},
                {"Revolver", "+3 Damage", "+10% Projectile Speed"},
                {"Revolver", "2 Round Burst", ""},
                {"Revolver", "+5 Damage", ""},
                {"Revolver", "+50% Bullet Size", ""},
                {"Revolver", "+20% Fire Rate", ""},
                {"Revolver", "3 Round Burst", ""},
                {"Revolver", "+10 Damage", ""}
            },
            {
                {"Shotgun", "Launches A Wide Spread Of Pellets", ""},
                {"Shotgun", "+1 pellet", ""},
                {"Shotgun", "+1 pellet", ""},
                {"Shotgun", "+1 pellet", ""},
                {"Shotgun", "+1 pellet", ""},
                {"Shotgun", "+1 pellet", ""},
                {"Shotgun", "+1 pellet", ""},
                {"Shotgun", "+1 pellet", ""},
                {"Shotgun", "+1 pellet", ""}
            },
            {
                {"Badge", "Throws A Star Forward", ""},
                {"Badge", "+20% Projectile Size", "+10% Projectile Speed"},
                {"Badge", "2 Round Burst", ""},
                {"Badge", "+20% Fire Rate", ""},
                {"Badge", "+10% Projectile Size", ""},
                {"Badge", "3 Round Burst", ""},
                {"Badge", "4 Round Burst", "+15% Projectile Speed"},
                {"Badge", "5 Round Burst", "+5 Damage"},
                {"Badge", "+20% Projectile Speed", "+20% Projectile Size"}
            },
            {
                {"Dynamite", "Lobs A Mining Exposive", ""},
                {"Dynamite", "+10 Damage", ""},
                {"Dynamite", "+10% Explosion Size", ""},
                {"Dynamite", "+10 Damage", ""},
                {"Dynamite", "+10% Explosion Size", ""},
                {"Dynamite", "+10 Damage", ""},
                {"Dynamite", "+10% Explosion Size", ""},
                {"Dynamite", "+10 Damage", ""},
                {"Dynamite", "+33% Fire Rate", ""}
            },
            {
                {"Gavel", "Tosses a Hammer Into The Air", ""},
                {"Gavel", "+20% Projectile Size", ""},
                {"Gavel", "3 Round Burst", ""},
                {"Gavel", "+16% Fire Rate", ""},
                {"Gavel", "+20% Projectile Size", "+5 Damage"},
                {"Gavel", "4 Round Burst", ""},
                {"Gavel", "5 Round Burst", "+5 Damage"},
                {"Gavel", "+16% Fire Rate", ""},
                {"Gavel", "+16% Fire Rate", ""}
            },
            {
                {"Worm Food", "Summons A Helpful Graboid", ""},
                {"Worm Food", "+10% Projectile Size", ""},
                {"Worm Food", "+5 Damage", ""},
                {"Worm Food", "+10% Projectile Size", "+16% Fire Rate"},
                {"Worm Food", "+10% Projectile Size", ""},
                {"Worm Food", "+5 Damage", ""},
                {"Worm Food", "+5 Damage", ""},
                {"Worm Food", "+10% Projectile Size", ""},
                {"Worm Food", "+16% Fire Rate", ""}
            },
            {
                {"Whip", "Attacks The Closest Enemy", ""},
                {"Whip", "+5 Damage", ""},
                {"Whip", "+16% Fire Rate", ""},
                {"Whip", "+5 Damage", ""},
                {"Whip", "+16% Fire Rate", ""},
                {"Whip", "+5 Damage", ""},
                {"Whip", "+16% Fire Rate", ""},
                {"Whip", "+5 Damage", ""},
                {"Whip", "+16% Fire Rate", ""}
            },
            {
                {"Intimidating aura", "Damages All Enemies Within Range", ""},
                {"Intimidating aura", "+25% Range", ""},
                {"Intimidating aura", "+2 Damage", ""},
                {"Intimidating aura", "+2 Damage", ""},
                {"Intimidating aura", "+20% Range", "+1 Damage"},
                {"Intimidating aura", "+25% Recharge", ""},
                {"Intimidating aura", "+2 Damage", ""},
                {"Intimidating aura", "+20% Range", ""},
                {"Intimidating aura", "+3 Damage", ""},
            }
        }
    };

    private Text[,] textboxes = new Text[3, 3];
    public Text[] textboxes0 = new Text[3];
    public Text[] textboxes1 = new Text[3];
    public Text[] textboxes2 = new Text[3];

    public Image[] iconSlots = new Image[3];

    public GameObject[] Panels = new GameObject[3];

    public Sprite[] weaponsspr = new Sprite[8];
    public Sprite[] passivesspr = new Sprite[8];

    private int[,] levels = new int[2, 8] { { 0, 0, 0, 0, 0, 0, 0, 0 }, { 1, 0, 0, 0, 0, 0, 0, 0 } };
    private bool[,] levelsbool = new bool[2, 8] { { false, false, false, false, false, false, false, false }, { true, false, false, false, false, false, false, false } };

    private int[,] slots = new int[3, 2] { {0, 0}, {0, 0}, {0, 0} };

    public Canvas canvas;
    public GameObject pause;

    public GameObject player;
    public GameObject mainUI;

    private int[] cnts = new int[2] {0, 1};

    private List<List<int>> valid = new List<List<int>>();

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainUI = GameObject.FindGameObjectWithTag("MainUI");
        for (int i = 0; i < 3; i++)
        {
            textboxes[0, i] = textboxes0[i];
        }
        for (int i = 0; i < 3; i++)
        {
            textboxes[1, i] = textboxes1[i];
        }
        for (int i = 0; i < 3; i++)
        {
            textboxes[2, i] = textboxes2[i];
        }
        pause = GameObject.Find("pause(Clone)");
        canvas.enabled = false;
    }

    public void load()
    {
        Time.timeScale = 0f;
        pause.SetActive(false);
        mainUI.SetActive(false);
        canvas.enabled = true;
        FindValid();
        int Ran;
        if (valid.Count >= 3)
        {
            for (int i = 0; i < 3; i++)
            {
                Ran = Random.Range(0, valid.Count);
                loadItem(i, valid[Ran][0], valid[Ran][1], valid[Ran][2]);
                slots[i, 0] = valid[Ran][0];
                slots[i, 1] = valid[Ran][1];
                valid.Remove(valid[Ran]);
            }
        }
        if (valid.Count == 2)
        {
            for (int i = 0; i < 2; i++)
            {
                Ran = Random.Range(0, valid.Count);
                loadItem(i, valid[Ran][0], valid[Ran][1], valid[Ran][2]);
                slots[i, 0] = valid[Ran][0];
                slots[i, 1] = valid[Ran][1];
                valid.Remove(valid[Ran]);
            }
            Ran = Random.Range(0, valid.Count);
            loadItem(2, valid[Ran][0], valid[Ran][1], valid[Ran][2]);
            slots[2, 0] = valid[Ran][0];
            slots[2, 1] = valid[Ran][1];
            valid.Remove(valid[Ran]);
        }
        if (valid.Count == 1)
        {
            for (int i = 0; i < 1; i++)
            {
                Ran = Random.Range(0, valid.Count);
                loadItem(i, valid[Ran][0], valid[Ran][1], valid[Ran][2]);
                slots[i, 0] = valid[Ran][0];
                slots[i, 1] = valid[Ran][1];
                valid.Remove(valid[Ran]);
            }
            Ran = Random.Range(0, valid.Count);
            loadItem(1, valid[Ran][0], valid[Ran][1], valid[Ran][2]);
            slots[1, 0] = valid[Ran][0];
            slots[1, 1] = valid[Ran][1];
            valid.Remove(valid[Ran]);
            Ran = Random.Range(0, valid.Count);
            loadItem(2, valid[Ran][0], valid[Ran][1], valid[Ran][2]);
            slots[2, 0] = valid[Ran][0];
            slots[2, 1] = valid[Ran][1];
            valid.Remove(valid[Ran]);

        }
        if (valid.Count == 0)
        {
            Debug.Log("0 Valid");
            Time.timeScale = 1f;
            pause.SetActive(true);
            canvas.enabled = false;
            mainUI.SetActive(true);
        }
    }

    private void loadItem(int box, int id, int weapon, int level)
    {
        if (weapon == 1)
        {
            iconSlots[box].sprite = weaponsspr[id];
        }
        else
        {
            iconSlots[box].sprite = passivesspr[id];
        }
        for (int i = 0; i < 3; i++)
        {
            textboxes[box, i].text = leveldetails[weapon, id, level, i];
        }
    }

    public void makeChoice(int num)
    {
        Debug.Log(valid.Count);
        player.GetComponent<PlayerBaseScript>().receivelevelup(slots[num, 0], slots[num, 1]);
        if (levels[slots[num, 1], slots[num, 0]] == 0)
        {
            cnts[slots[num, 1]] += 1;
            levelsbool[slots[num, 1], slots[num, 0]] = true;
        }
        levels[slots[num, 1], slots[num, 0]] += 1;
        Time.timeScale = 1f;
        pause.SetActive(true);
        canvas.enabled = false;
        mainUI.SetActive(true);
    }


    private void FindValid()
    {
        valid.Clear();
        int validcnt = 0;
        //I = 0 means passives
        //I = 1 means weapons
        for (int i = 0; i < 2; i++)
        {
            
            for (int h = 0; h < 8; h++)
            {
                //Passives
                if (i == 0 && levels[i, h] == 0)
                {
                    //If we do not have 6 passives & the passive is not max level
                    if (cnts[0] != 6)
                    {
                        valid.Add(new List<int>());
                        valid[validcnt].Add(h);
                        valid[validcnt].Add(i);
                        valid[validcnt].Add(levels[i, h]);
                        validcnt += 1;
                    }
                }
                //Weapons
                else if (i == 1 && levels[i, h] < 9)
                {
                    //If we do not have 6 weapons & the weapon Not (have 6 weapons OR NOTMaxlevl)
                    if (cnts[1] != 6 || !levelsbool[i, h])
                    {
                        valid.Add(new List<int>());
                        valid[validcnt].Add(h);
                        valid[validcnt].Add(i);
                        valid[validcnt].Add(levels[i, h]);
                        validcnt += 1;
                    }
                }
            }
        }
    }
}
