using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathscreenscript : MonoBehaviour
{
    GameObject player;
    GameObject background;
    GameObject loader;
    public GameObject loaderPrefab;
    GameObject menu;
    public GameObject Mainmenu;
    public GameObject spawner;
    // Start is called before the first frame update

    public void Restart()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        player = GameObject.FindGameObjectWithTag("Player");
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
        foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            Destroy(bullet);
        }
        foreach (GameObject ui in GameObject.FindGameObjectsWithTag("ToBeDeleted"))
        {
            Destroy(ui);
        }
        background = GameObject.FindGameObjectWithTag("background");

        Destroy(player);
        Destroy(background);
        loader = Instantiate(loaderPrefab, new Vector3(0f, 0f, 0f), transform.rotation);
        Destroy(gameObject);
    }

    public void Quit()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        player = GameObject.FindGameObjectWithTag("Player");
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
        foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            Destroy(bullet);
        }
        foreach (GameObject ui in GameObject.FindGameObjectsWithTag("ToBeDeleted"))
        {
            Destroy(ui);
        }
        background = GameObject.FindGameObjectWithTag("background");

        Destroy(player);
        Destroy(background);
        menu = Instantiate(Mainmenu, new Vector3(0f, 0f, 0f), transform.rotation);
        Destroy(gameObject);
    }

}
