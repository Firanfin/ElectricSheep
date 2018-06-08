using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This is a struct that forms one line of Dialogue in the game.
 * It includes the type of the conversation, the name of the speaker
 * and the the contents of the line itself. */
public struct DialogueLine
{
    // Properties
    public ConvType type;
    public Speaker name;
    public string content;

    // Constructor
    public DialogueLine(ConvType type, Speaker name, string content)
    {
        this.type = type;
        this.name = name;
        this.content = content;
    }

}
