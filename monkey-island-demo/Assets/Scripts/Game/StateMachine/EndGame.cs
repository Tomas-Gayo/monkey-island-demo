using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : State
{
    private int enemy;
    private int player;

    // Some data needs to be passed from the previous state, so we have to declare it on the constructor
    public EndGame(GameplayManager gameplayManager, int enemyHealth, int playerHealth) : base(gameplayManager)
    {
        enemy = enemyHealth;
        player = playerHealth;
    }

    // Now is time to decide if the game continues or ends
    public override IEnumerator Start()
    {
        Debug.Log("isTurnFinal ---> Enemy:" + enemy + "Player:" + player);

        yield return new WaitForSeconds(3f);

        // Stop all the animations
        AnimatorStates.isPlayerAttacking = false;
        AnimatorStates.isEnemyAttacking = false;
        AnimatorStates.isPlayerHurt = false;
        AnimatorStates.isEnemyHurt = false;

        // the first character to reach zero lifes loses and the winner is asigned
        // trigger for death animation and sound
        // finally, the "End Screen" is displayed
        // But if the game has not end (still more than one life for each character) 
        // the game continues and the begin state is asigned 
        if (player == 0)
        {
            SoundManager.PlaySound("death");
            Winner.isEnemy = true;
            AnimatorStates.isPlayerDeath = true;

            yield return new WaitForSeconds(2f);

            AnimatorStates.isPlayerDeath = false;

            SceneManager.LoadScene("EndScreen");
        }
        else if (enemy == 0)
        {
            SoundManager.PlaySound("death");
            Winner.isPlayer = true;
            AnimatorStates.isEnemyDeath = true;

            yield return new WaitForSeconds(2f);

            AnimatorStates.isEnemyDeath = false;

            SceneManager.LoadScene("EndScreen");
        }
        else
        {
            GameplayManager.SetState(new Begin(GameplayManager));
        }
    }
}
