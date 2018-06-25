using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is designed to be put on the button, that advances the dialogue
public class DialogueTrigger : MonoBehaviour {

    // ---------- Properties ----------

    //public string dialogueFileName;

    public TextAsset textAsset;

    public DialogueManager manager;


    //public void TriggerDialogue()
    //{
    //	manager.StartDialogue(new Dialogue(dialogueFileName));
    //}

    // ---------- Methods ----------

    public void TriggerDialogue()
    {
        manager.StartDialogue(new Dialogue(textAsset));
    }


}
