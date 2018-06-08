using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour {


    // The class question hold the information of one question tree. 
    public class Question
    {
        // Properties
        string questionName;
        string dialogueFileName;
        DialogueLine[] conversation;
        DialogueLine[][] choices;
        bool used;
        int aggro;

        // Constructor
        public Question(string dialogueFileName)
        {
            used = false;
            this.dialogueFileName = dialogueFileName;
            choices = new DialogueLine[3][];


            // Using ParseDialogue to create an array of lines
            DialogueLine[] allLines = ParseDialogue(dialogueFileName);


            // Using SortDialogue to place parsed lines into their respective arrays
            conversation = SortDialogue(allLines, ConvType.Conversation);
            choices[0] = SortDialogue(allLines, ConvType.Choice1);
            choices[1] = SortDialogue(allLines, ConvType.Choice2);
            choices[2] = SortDialogue(allLines, ConvType.Choice3);

            questionName = conversation[0].content;
        }

        

        /* This method is designed to be a shorthand for sorting the contents of 
         * a DialogueList into smaller pieces according to their conversation type.
         * It is called in the Start() method. Its arguments are the list, that is
         * being sorted and the type with which the sorting will be done.
         * */
        public DialogueLine[] SortDialogue(DialogueLine[] argument, ConvType type)
        {
            List<DialogueLine> dialogueListHelper = new List<DialogueLine>();
            int counterHelper = 0;

            foreach (DialogueLine oneLine in argument)
            {
                if (oneLine.type == type)
                {
                    dialogueListHelper.Add(oneLine);
                    counterHelper++;
                }
            }

            DialogueLine[] result = new DialogueLine[counterHelper];
            for (int i = 0; i < counterHelper; i++)
            {
                result[i] = dialogueListHelper[i];
            }
            return result;
        }



        public void AskQuestion()
        {
            this.used = true;

        }

        /* A method that takes a text file and makes it into an array of DialogueLine objects.
         * After this, it is easier to work with them. It takes the name of the file as a string
         * and returns a DialogueLine[]. */
        public DialogueLine[] ParseDialogue(string fileName)
        {
            string[] linesToBeParsed = File.ReadAllLines(fileName);
            DialogueLine[] result = new DialogueLine[linesToBeParsed.Length];

            for (int i = 0; i < linesToBeParsed.Length; i++)
            {
                ConvType convType = (ConvType)Enum.Parse(typeof(ConvType), linesToBeParsed[i].Split(';')[0]);
                Speaker speakerName = (Speaker)Enum.Parse(typeof(Speaker), linesToBeParsed[i].Split(';')[1]);
                string content = linesToBeParsed[i].Split(';')[2];

                result[i] = new DialogueLine(convType, speakerName, content);

            }
            return result;

        }

    }

    // These are the questions of this particular scene
    public Question[] questions;
    public Question[] controlQuestions;

	// Use this for initialization
	void Start () {


        // Empty arrays for questions
        controlQuestions = new Question[3];
        questions = new Question[12];

        
        string filePath = "Assets/Dialogue/" + SceneManager.GetActiveScene().name;
        
        // Assigning somethig to the empty arrays. At the same time the questons are actually made.
        for (int i = 1; i < 4; i++)
        {
            controlQuestions[i - 1] = new Question("Assets/Dialogue/Control/Question" + i + ".txt");
        }

        for (int i = 0; i < 12; i++)
        {
            int counter = i + 1;
            questions[i] = new Question(filePath + "/Question" + counter + ".txt");
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
