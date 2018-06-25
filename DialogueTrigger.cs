using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    //public string dialogueFileName;
    public TextAsset textAsset;
    public DialogueManager manager;
    
    // Check, what we should do next
    public void ReactToDialogueRequest()
    {

    }
    // If end of file, ask the gamemaster, what to do
    // If file continues, start next dialogue


    //public void TriggerDialogue()
    //{
    //	manager.StartDialogue(new Dialogue(dialogueFileName));
    //}

    public void TriggerDialogue()
    {
        manager.StartDialogue(new Dialogue(textAsset));
    }


}
