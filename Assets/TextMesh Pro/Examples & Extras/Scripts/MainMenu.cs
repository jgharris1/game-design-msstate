
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    //Play Game
    public void Play(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    //Quit Game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Thanks for playing!");
    }
}
