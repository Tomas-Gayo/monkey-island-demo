using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerTurn : State
{
    public PlayerTurn(GameplayManager gameplayManager) : base(gameplayManager)
    {
    }

    // In the player turn, choose an option for the enemy first (don't display yet)
    // Then wait untuil the player choose an insult 
    public override IEnumerator Start()
    {
        int optionsSize = GameplayManager.jsonReader.getOptionsSize();
        int enemyIndex = Random.Range(0, optionsSize);

        var answer = GameplayManager.jsonReader.getOptionByID(enemyIndex).answer;

        for (int playerIndex = 0; playerIndex < optionsSize; playerIndex++)
        {
            var optionButtonCopy = Object.Instantiate(GameplayManager.OptionsPrefab, GameplayManager.PlayerInterface, false);

            var insult = GameplayManager.jsonReader.getOptionByID(playerIndex).insult;
            
            // Add text to the option button for each iteration so we have all the selectable options for the user
            optionButtonCopy.GetComponentInChildren<TextMeshProUGUI>().text = insult;

            // This method will add a listener to each option, once is triggered we send all the information
            Insult(optionButtonCopy.GetComponent<Button>(), insult, answer, enemyIndex, playerIndex);
        }
        yield break;
    }

    // Once this method retreive the info the screen shows the insult and the selectable options are removed 
    private void Insult(Button button, string insultDialogue, string answerText, int enemyIndex, int playerIndex)
    {
        button.onClick.AddListener(() => {
            GameplayManager.Interface.SetDialogueText("JUGADOR: " + insultDialogue);
            GameplayManager.Interface.cleanUI(GameplayManager.PlayerInterface);
            GameplayManager.StartCoroutine(Answer(answerText, enemyIndex, playerIndex));
        });
    }

    // After the player plays the turn the enemy answer is displayed but the user is forced to click a "Continue" button
    // This way the enemy text is not set automatically and the player has time to read all with tranquility 
    private IEnumerator Answer(string textdialogue, int enemyIndex, int playerIndex)
    {
        var continueButton = Object.Instantiate(GameplayManager.ContinueButton, GameplayManager.DialogueInterface, true);

        yield return new WaitForSeconds(2f);

        continueButton.SetActive(true);
        continueButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            continueButton.SetActive(false);
            GameplayManager.Interface.SetDialogueText("ENEMIGO: " + textdialogue);
            //Let's see who wins the turn by passing the relevant information to the End Turn method
            GameplayManager.StartCoroutine(EndTurn(enemyIndex, playerIndex));
        });
    }

    // Depending on the indexes (which correspond with the ids of the insults and answers)
    //
    // ->> The JSON file has groups of 3 values: id, insult and answer
    //
    // The EndTurn will decide the winner, in this case is the player turn
    // so if the indexes are different the player wins because the enemy has not get right the anwser
    // Also, the sounds and animations are played and the character who lost loses one heart
    // At the end, the state machine changes to the End Game state which is responsible to decide if the game has end
    public override IEnumerator EndTurn(int enemyIndex, int playerIndex)
    {
        yield return new WaitForSeconds(2f);

        if (enemyIndex != playerIndex)
        {
            SoundManager.PlaySound("attack");
            SoundManager.PlaySound("hurt");
            AnimatorStates.isPlayerAttacking = true;
            AnimatorStates.isEnemyHurt = true;
            GameplayManager.enemyHealth -= 1;
            GameplayManager.enemy.AddDamage(GameplayManager.enemyHealth);
            GameplayManager.isTurn = false;
        }
        else if (enemyIndex == playerIndex)
        {
            SoundManager.PlaySound("attack");
            SoundManager.PlaySound("hurt");
            AnimatorStates.isEnemyAttacking = true;
            AnimatorStates.isPlayerHurt = true;
            GameplayManager.playerHealth -= 1;
            GameplayManager.player.AddDamage(GameplayManager.playerHealth);
            GameplayManager.isTurn = true;
        }
        GameplayManager.SetState(new EndGame(GameplayManager, GameplayManager.enemyHealth, GameplayManager.playerHealth));
    }      
}
