using UnityEngine;
using UnityEngine.SceneManagement;

// Simple class to handle the actions of the buttons in the "Main screen"
public class MainMenuScreen : MonoBehaviour
{
    public GameObject MainMenuUI;

    public void NewGame()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}