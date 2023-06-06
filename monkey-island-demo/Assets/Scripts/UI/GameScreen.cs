using System.Collections;
using UnityEngine;
using TMPro;

// In this class there are needed methods to handle the "Game screen" 
public class GameScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField] float typingSpeed;

    private int index;

    // With this method it is possible to "animate" the typing in the dialogue interface
    private IEnumerator Type(string sentence)
    {
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            SoundManager.PlaySound("type");
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // Method used constantly to fill the text on the dialogue interface
    public void SetDialogueText(string sentence)
    {
        if(index < sentence.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(Type(sentence));
        }
        else
        {
            dialogueText.text = string.Empty;
        }
    }

    // Method to destroy the childs of the GameObject parents
    public void cleanUI(Transform dialogue)
    {
        foreach (Transform child in dialogue)
        {
            Destroy(child.gameObject);
        }
    }
}
