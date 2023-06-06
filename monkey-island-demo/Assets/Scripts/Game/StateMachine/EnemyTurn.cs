using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyTurn : State
{
    public EnemyTurn(GameplayManager gameplayManager) : base(gameplayManager)
    {
    }

    // In the enemy turn, choose an option for the enemy first (and display it)
    // Then wait untuil the player choose an answer 
    public override IEnumerator Start()
    {
        int optionsSize = GameplayManager.jsonReader.getOptionsSize();
        int enemyIndex = Random.Range(0, optionsSize);

        var insult = GameplayManager.jsonReader.getOptionByID(enemyIndex).insult;

        GameplayManager.Interface.SetDialogueText("ENEMIGO: " + insult);

        yield return new WaitForSeconds(2f);

        for (int playerIndex = 0; playerIndex < optionsSize; playerIndex++)
        {
            var optionButtonCopy = Object.Instantiate(GameplayManager.OptionsPrefab, GameplayManager.PlayerInterface, false);

            var answer = GameplayManager.jsonReader.getOptionByID(playerIndex).answer;

            // Add text to the option button for each iteration so we have all the selectable options for the user
            optionButtonCopy.GetComponentInChildren<TextMeshProUGUI>().text = answer;

            // This method will add a listener to each option, once is triggered we send all the information
            Insult(optionButtonCopy.GetComponent<Button>(), answer, enemyIndex, playerIndex);
        }
    }

    // Once this method retreive the info the screen shows the answer and the selectable options are removed 
    private void Insult(Button button, string answer, int enemyIndex, int playerIndex)
    {
        button.onClick.AddListener(() => {
            GameplayManager.Interface.SetDialogueText("JUGADOR: " + answer);
            GameplayManager.Interface.cleanUI(GameplayManager.PlayerInterface);
            GameplayManager.StartCoroutine(EndTurn(enemyIndex, playerIndex));
        });
    }

    // Depending on the indexes (which correspond with the ids of the insults and answers)
    //
    // ->> The JSON file has groups of 3 values: id, insult and answer
    //
    // The EndTurn will decide the winner, in this case is the enemy turn
    // so if the indexes are different the enemy wins because the player has not get right the anwser
    // Also, the sounds and animations are played and the character who lost loses one heart
    // At the end, the state machine changes to the End Game state which is responsible to decide if the game has end
    public override IEnumerator EndTurn(int enemyIndex, int playerIndex)
    {

        yield return new WaitForSeconds(2f);

        if (enemyIndex != playerIndex)
        {
            SoundManager.PlaySound("attack");
            SoundManager.PlaySound("hurt");
            AnimatorStates.isEnemyAttacking = true;
            AnimatorStates.isPlayerHurt = true;
            GameplayManager.playerHealth -= 1;
            GameplayManager.player.AddDamage(GameplayManager.playerHealth);
            GameplayManager.isTurn = true;
        }
        else if (enemyIndex == playerIndex)
        {
            SoundManager.PlaySound("attack");
            SoundManager.PlaySound("hurt");
            AnimatorStates.isPlayerAttacking = true;
            AnimatorStates.isEnemyHurt = true;
            GameplayManager.enemyHealth -= 1;
            GameplayManager.enemy.AddDamage(GameplayManager.enemyHealth);
            GameplayManager.isTurn = false;
        }
        GameplayManager.SetState(new EndGame(GameplayManager, GameplayManager.enemyHealth, GameplayManager.playerHealth));
    }
}
