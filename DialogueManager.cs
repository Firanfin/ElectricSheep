using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	private Queue<DialogueLine> allLines;
    private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		allLines = new Queue<DialogueLine>();
        sentences = new Queue<string>();
	}
    

    /* A method, that is called when a person begins to speak. Takes one argument
     * of type DialogueLine and doesn't return anythng. Uses the Queue<string>
     * property of the class, to go through all lines.
     * */
	public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("DialogueOpen", true);

		allLines.Clear();
        foreach (DialogueLine dialogueLine in dialogue.content)
        {
            allLines.Enqueue(dialogueLine);
        }

        NextSpeaker();
	}

    /* Starts the monologue of the next speaker in the allLines queue.
     * If allLines queue is empty, the dialogue has ended.
     * */
    public void NextSpeaker()
    {
        if (allLines.Count == 0)
        {
            EndDialogue();
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

    /* Displays the next line in the queue and removes it at the same time.
     * If the queue is empty, all lines of the monologue have been shown.
     * Call the next speaker.
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

    /* A coroutine, that simlpy makes the characters of one line
     * to appear one by one on the screen.
     * */
	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}


    /* A method run at the end of the Dialogue. It just tells the animator to
     * close the dialogue box.
     * */
	void EndDialogue()
	{
		animator.SetBool("DialogueOpen", false);

        //FindObjectOfType<GameMaster>().AdvanceGame(dialogue);
    }

}
