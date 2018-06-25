using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Each dialogue can have options from which the player can choose
// This class represents one of such an option
public class DialogueOption {
    
    // ---------- Properties ----------

    // The type of the option for example "Evidence" or "Very Aggressive"
    public string type;

    // The actual option as a string for display purposes
    public string text;

    // The filepath of the file to which this option leads
    public string destinationFile;
    
}
