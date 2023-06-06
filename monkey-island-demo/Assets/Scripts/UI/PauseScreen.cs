using UnityEngine;
using UnityEngine.SceneManagement;

// Simple class to handle the actions of the buttons when the game is paused
public class PauseScreen : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public static bool isPaused = false;

    // ESC key will be the trigger to pause the sceeen
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // With Time.timeScale we can pause the game when is paused
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScreen");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScreen");
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
