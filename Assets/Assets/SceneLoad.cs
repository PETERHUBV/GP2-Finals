using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour
{
    public GameObject[] characterModels;
    public Text dialogueText;
    public Button[] choiceButtons;

    [System.Serializable]
    public class CharacterDialogue
    {
        public string characterName;
        public string[] lines;
        public DialogueChoice[] choices;
    }

    [System.Serializable]
    public class DialogueChoice
    {
        public string choiceText;
        public CharacterDialogue nextDialogue;  
    }

    public CharacterDialogue[] characterDialogues; 
    private CharacterDialogue currentDialogue; 
    private int currentLineIndex = 0;
    private bool isDialogueActive = false;

private void Start()
    {
        foreach (Button button in choiceButtons)
        {
            button.gameObject.SetActive(false); 
        }

        if (characterModels.Length > 0 && characterDialogues.Length > 0)
        {
            foreach (var character in characterModels)
            {
                character.SetActive(false); 
            }

            ShowCharacterDialogue(characterDialogues[0]);
        }
        else
        {
            Debug.LogError("Character models or dialogues are missing.");
        }
    }

private  void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && isDialogueActive)
        {
            DisplayDialogue();
        }

       
        if (Input.GetKeyDown(KeyCode.C))
        {
            int nextIndex = (System.Array.IndexOf(characterDialogues, currentDialogue) + 1) % characterDialogues.Length;
            ShowCharacterDialogue(characterDialogues[nextIndex]);
        }

        
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleCharacterVisibility();
        }
    }

    void ToggleCharacterVisibility()
    {
        for (int i = 0; i < characterModels.Length; i++)
        {
            characterModels[i].SetActive(!characterModels[i].activeSelf);
        }
    }

    void ShowCharacterDialogue(CharacterDialogue dialogue)
    {
        currentDialogue = dialogue;  
        currentLineIndex = 0;        
        isDialogueActive = true;
        dialogueText.text = currentDialogue.characterName + ": " + currentDialogue.lines[currentLineIndex];
        currentLineIndex++;

       
        if (currentDialogue.choices.Length > 0)
        {
            ShowChoices(currentDialogue.choices);
        }
        else
        {
           
            choiceButtons[0].gameObject.SetActive(false);
        }
    }

    void DisplayDialogue()
    {
        if (currentLineIndex < currentDialogue.lines.Length)
        {
           
            dialogueText.text = currentDialogue.characterName + ": " + currentDialogue.lines[currentLineIndex];
            currentLineIndex++;  
        }
        else
        {
           
            choiceButtons[0].gameObject.SetActive(false);  
        }
    }

    void ShowChoices(DialogueChoice[] choices)
    {
        dialogueText.text += "\nChoose an option:"; 
        for (int i = 0; i < choices.Length; i++)
        {
            choiceButtons[i].gameObject.SetActive(true);  

           
            choiceButtons[i].GetComponentInChildren<Text>().text = choices[i].choiceText;

           
            int index = i; 
            choiceButtons[i].onClick.RemoveAllListeners(); 
            choiceButtons[i].onClick.AddListener(() => OnChoiceSelected(choices[index]));
        }
    }

public void OnChoiceSelected(DialogueChoice selectedChoice)
    {
       
        foreach (Button button in choiceButtons)
        {
            button.gameObject.SetActive(false);
        }

       
        if (selectedChoice.nextDialogue != null)
        {
            ShowCharacterDialogue(selectedChoice.nextDialogue);
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
       
        isDialogueActive = false;
        dialogueText.text = "End of dialogue.";
        Debug.Log("Dialogue has ended.");
    }
}