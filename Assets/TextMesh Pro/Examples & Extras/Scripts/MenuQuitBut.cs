using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Play Game
    public void Playbutton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //Quit Game
    public void Quitbutton()
    {
        Application.Quit();
        Debug.Log("Thanks for playing!");
    }
}
