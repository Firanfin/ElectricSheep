using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{

    //// These are the questions of this particular scene
    //public Question[] questions;
    //public Question[] controlQuestions;
    //public DialogueLine[] greeting;

    //// Use this for initialization
    //void Start()
    //{


    //    // Empty arrays for questions
    //    controlQuestions = new Question[3];
    //    questions = new Question[12];


    //    string filePath = "Assets/Dialogue/" + SceneManager.GetActiveScene().name;

    //    // Assigning somethig to the empty arrays. At the same time the questons are actually made.
    //    for (int i = 0; i < 3; i++)
    //    {
    //        int counter = i + 1;
    //        controlQuestions[i] = new Question("Assets/Dialogue/Control/Question" + counter + ".txt");
    //    }

    //    for (int i = 0; i < 12; i++)
    //    {
    //        int counter = i + 1;
    //        questions[i] = new Question(filePath + "/Question" + counter + ".txt");
    //    }

    //    // The greeting is not a question, just a simple DialogueLine array,
    //    // so it is made straight up with the ParseDialogue method.
    //    greeting = Question.ParseDialogue(filePath + "/Greeting.txt");


    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
