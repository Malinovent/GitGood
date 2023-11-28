using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text blockText;
    [SerializeField] Image characterPortrait;
    [SerializeField] GameObject dialogueGameObject;

    private int textIndex = 0;
    private DialogueData currentDialogue;

    public static DialogueManager Singleton;

    private void Awake()
    {
        if(Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void StartDialogue(DialogueData data)
    {
        textIndex = 0;
        currentDialogue = data;
        dialogueGameObject.SetActive(true);

        NextDialogue();
    }

    public void NextDialogue()
    {
        if (textIndex >= currentDialogue.boxText.Length)
        {
            FinishDialogue();
            return;
        }

        nameText.text = currentDialogue.characterName;
        blockText.text = currentDialogue.boxText[textIndex];
        characterPortrait.sprite = currentDialogue.characterPortait;

        textIndex++;
        
    }

    private void FinishDialogue()
    {
        dialogueGameObject.SetActive(false);
    }

}
