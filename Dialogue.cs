using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

/* An instance of this class will hold the information of one dialogue data file.
 * All lines to be displayed after a choice is made, wether this dialogue has already
 * been used and the max 3 choices that will follow this particular dialogue.
 * */
[Serializable]
public class Dialogue
{
    // ---------- Properties -----------

    // The text to be displayed in easy to display format
    public DialogueLine[] content;

    // A boolean that indicates, wether this dialogue has already been used
    public bool used = false;

    // The dialogue options that the player can chooce from after the content of this dialogue
    public DialogueOption[] options;


    // ---------- Constructors ----------

    // One without arguments, needed when converting from json files
    public Dialogue() { }

    // One that takes a filename as an argument
    public Dialogue(string dialogueFileName) : this()
    {
        string filePath = "Assets/Dialogue/" + SceneManager.GetActiveScene().name + "/" + dialogueFileName;
        string jString = new StreamReader(filePath).ReadToEnd();
        Dialogue dialogue = JsonConvert.DeserializeObject<Dialogue>(jString);
        
        content = dialogue.content;
        used = dialogue.used;
        options = dialogue.options;
    }

    // One that takes a preassosiated text asset as an argument
    public Dialogue(TextAsset file)
    {

        string jString = file.text;
        Dialogue dialogue = JsonConvert.DeserializeObject<Dialogue>(jString);
        
        content = dialogue.content;
        used = dialogue.used;
        options = dialogue.options;
    }

}


