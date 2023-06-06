using System.Collections;
using UnityEngine;
public class Begin : State
{
    public Begin(GameplayManager gameplayManager) : base(gameplayManager)
    {
    }

    // In the "Begin" state the scene is prepared to start a turn
    public override IEnumerator Start()
    {
        GameplayManager.Interface.SetDialogueText(string.Empty);

        //force the animations to default values
        AnimatorStates.isPlayerAttacking = false;
        AnimatorStates.isEnemyAttacking = false;
        AnimatorStates.isPlayerHurt = false;
        AnimatorStates.isEnemyHurt = false;
        AnimatorStates.isPlayerDeath = false;
        AnimatorStates.isEnemyDeath = false;

        yield return new WaitForSeconds(0.5f);

        // Player Turn
        if (!GameplayManager.isTurn)
        {
            GameplayManager.SetState(new PlayerTurn(GameplayManager));
            Debug.Log("Turno del jugador");
        }
        // Enemy turn
        else
        {
            GameplayManager.SetState(new EnemyTurn(GameplayManager));
            Debug.Log("turno del enemigo");
        }
    }
}
