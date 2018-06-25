using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/* This class is the one that takes care of most of the dialogue. It is designed to be
 * put on some abstract game manager object.
 * */
public class DialogueManager : MonoBehaviour {

    // ---------- Properties ----------

    // A reference to the text box that displys the name of the speaker
	public Text nameText;

    // A reference to the text box that displays the content of the dialogue
	public Text dialogueText;

    // An array of references for the buttons that will display the options
    public GameObject[] buttons;

    // A reference for the animator of the dialogue panel
	public Animator animator;

    // A queue that stores all dialogue lines of this dialogue, easy to manipulate further
	private Queue<DialogueLine> allLines;

    // A queue that is used to display the sentences of one dialogue line
    private Queue<string> sentences;

    // An array that stores the options related to this dialogue
    private DialogueOption[] options;

    // ---------- Methods ----------

	// Use this for initialization
	void Start () {
		allLines = new Queue<DialogueLine>();
        sentences = new Queue<string>();
	}
    

    /* A method, that is called when a dialogue starts. Takes one argument
     * of type Dialogue and doesn't return anythng. It activates the animator
     * to open the dialogue panel. It clears the buttons of any text and
     * queues the lines of this Dialogue into the allLines queue. At the
     * same time it stores the options of this dialogue to the appropriate
     * property and calls for the NextSpeaker() method.
     * */
	public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("DialogueOpen", true);

        foreach (GameObject button in buttons)
        {
            button.GetComponentInChildren<Text>().text = "";
        }

        allLines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.content)
        {
            allLines.Enqueue(dialogueLine);
        }

        options = dialogue.options;

        NextSpeaker();

	}

    /* Starts the monologue of the next speaker in the allLines queue.
     * If allLines queue is empty, the dialogue has ended and it calls
     * the GenerateOptions() method. If there are still lines in the queue,
     * it names the speaker and makes a queue of the sentences to be displayed.
     * */
    public void NextSpeaker()
    {
        if (allLines.Count == 0)
        {
            GerenateOptions(options);
            return;
        }

        DialogueLine dialogueLine = allLines.Dequeue();
        nameText.text = dialogueLine.name;

        foreach (string sentence in dialogueLine.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();

    }

    /* This method assigns the contents of the "options" array to buttons so that the player can use them.
     * 
     * */
    public void GerenateOptions(DialogueOption[] options)
    {
        for (int i = 0; i < 3; i++)
        {
            if (options[i] == null)
            {
                return;
            }
            buttons[i].SetActive(true);
            buttons[i].GetComponentInChildren<Text>().text = options[i].text;
            buttons[i].GetComponent<DialogueTrigger>().textAsset = 
                (TextAsset)AssetDatabase.LoadAssetAtPath("Assets/Dialogue/InterrogationScene1/" + options[i].destinationFile, typeof(TextAsset));
        }
    }

    /* Displays the next line in the queue and removes it at the same time.
     * If the queue is empty, all lines of the monologue have been shown,
     * and it calls the next speaker.
     * */
	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
            NextSpeaker();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

    /* A coroutine, that simlpy makes the characters of a line
     * of text to appear one by one on the screen. It uses a custom
     * GameConstant class to define the delay between characters
     * */
	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
            yield return new WaitForSeconds(GameConstants.textSpeed);
        }
	}


    /* A method run at the end of the Dialogue. It just tells the animator to
     * close the dialogue panel
     * */
	void EndDialogue()
	{
		animator.SetBool("DialogueOpen", false);

        //FindObjectOfType<GameMaster>().AdvanceGame(dialogue);
    }

}
