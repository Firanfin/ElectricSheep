using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DialogueOrgaizer : MonoBehaviour {

    [SerializeField]
    Dictionary<string, Dialogue> dialogueDatabase;

	// Use this for initialization
	void Start () {

        dialogueDatabase = new Dictionary<string, Dialogue>();
        dialogueDatabase = CreateDDB("/Assets/Dialogue/" + SceneManager.GetActiveScene() + "Test");
	}

    private Dictionary<string, Dialogue> CreateDDB(string filePath)
    {
        Dictionary<int, Dialogue> result = new Dictionary<int, Dialogue>();

        int i = 1;
        while (File.Exists(filePath + i + ".json"))
        {
            Dialogue dialogue = new Dialogue(filePath + i + ".json");

            result.Add(dialogue.key, dialogue);

            i++;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
