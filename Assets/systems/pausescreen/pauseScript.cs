using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseUI;

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
}
