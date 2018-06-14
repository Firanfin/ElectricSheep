using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/* This is a class that forms one line of Dialogue in the game.
 * It includes the type of the conversation, the name of the speaker
 * and the the contents of the line itself. */
[System.Serializable]
public class DialogueLine
{
    // Properties
    public string type;
    public string name;
    public string[] sentences;
}
