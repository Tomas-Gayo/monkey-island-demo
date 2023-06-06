using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Simple class to handle the actions of the buttons in the "End screen"
public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI EndText;

    // The screen shows the result of the current game once is finished
    private void Start()
    {
        EndText.text = string.Empty;
        if (Winner.isPlayer == true)
        {
            EndText.text = "¡VICTORIA!";
            Winner.isPlayer = false;
        }
        else if (Winner.isEnemy == true)
        {
            EndText.text = "¡DERROTA!";
            Winner.isEnemy = false;
        }
    }
    public void NewGame()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}