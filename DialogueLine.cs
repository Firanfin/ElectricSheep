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
    // ---------- Properties ----------

    // The type of the line
    public string type = "";

    // The name of the speaker
    public string name = "";

    // This array consists of all the consecutive sentences of one speaker
    public string[] sentences;
}
