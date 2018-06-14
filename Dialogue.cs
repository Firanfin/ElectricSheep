﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class Dialogue
{
    // Properties
    public string nextFile;
    public DialogueLine[] content;
    public bool used;

    // Constructor
    public Dialogue(string dialogueFileName)
    {
        string filePath = "C:/Users/Rami-Roope/Documents/Opiskelu/Pelinkehittäjä/Electric Sheep/Electric Sheep WIP/Assets/Dialogue/"
            + SceneManager.GetActiveScene().name + "/" + dialogueFileName;
        string jString = new StreamReader(filePath).ReadToEnd();
        Dialogue dialogue = JsonConvert.DeserializeObject<Dialogue>(jString);

        nextFile = dialogue.nextFile;
        content = dialogue.content;
        used = dialogue.used;
    }



    /* This method is designed to be a shorthand for sorting the contents of 
     * a DialogueList into smaller pieces according to their conversation type.
     * It is called in the Start() method. Its arguments are the list, that is
     * being sorted and the type with which the sorting will be done.
     * */
    //public DialogueLine[] SortDialogue(DialogueLine[] argument, ConvType type)
    //{
    //    List<DialogueLine> dialogueListHelper = new List<DialogueLine>();
    //    int counterHelper = 0;

    //    foreach (DialogueLine oneLine in argument)
    //    {
    //        if (oneLine.type == type)
    //        {
    //            dialogueListHelper.Add(oneLine);
    //            counterHelper++;
    //        }
    //    }

    //    DialogueLine[] result = new DialogueLine[counterHelper];
    //    for (int i = 0; i < counterHelper; i++)
    //    {
    //        result[i] = dialogueListHelper[i];
    //    }
    //    return result;
    //}
    //public void AskQuestion()
    //{
    //    this.used = true;
    //}
    

}

