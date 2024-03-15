using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseUI;
    GameObject player;
    GameObject background;
    GameObject menu;
    public GameObject Mainmenu;
    GameObject death;
    public GameObject spawner;

    void Start()
    {
        death = GameObject.Find("deathscreen(Clone)");
    }

    public void NotQuiteStart()
    {
        pauseUI=GameObject.FindGameObjectWithTag("pausescreen");
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    void PauseGame()
    {
        pauseUI.SetActive(true);
            Time.timeScale = 0f;
            paused = true;
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
        Destroy(death);
        Time.timeScale = 1f;
    }
}
