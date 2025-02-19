using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Start Game");
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void StartScreen()
    {
        SceneManager.LoadScene("Start Screen");
    }
}
