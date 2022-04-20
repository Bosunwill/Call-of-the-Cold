using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    bool scriptIsRunning = false;

    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText ;

    public GameObject textBox;
    public GameObject continueButton;

    public playerController player;

    void Start()
    {
        //creates a list of strings to be our sentences
        sentences = new Queue<string>();
        textBox.SetActive(false);
    }

    void Update()
    {
        if(scriptIsRunning)
        {
            player.enabled = false;
        }
        else if(!scriptIsRunning)
        {
            player.enabled = true;
        }
    }

    public void StartDialogue (Dialogue dialogue)
    {

        if(!scriptIsRunning)
        {
            nameText.text = dialogue.name;
            scriptIsRunning = true;

            //clears any previously left over sentences
            sentences.Clear();
            //activate texxtBox
            textBox.SetActive(true);

            foreach(string sentence in dialogue.sentences)
            {
                //adds lines from the Dialogue array "sentences" to this scripts queue "sentences"
                sentences.Enqueue(sentence);
            }
            DisplayNextSentence(); 
        }

        

    }

    public void DisplayNextSentence()
    {
        //Checks if dialogue has ended
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        //gets rid of current sentence for new one
        string sentence = sentences.Dequeue();
        // StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //animates dialogue;
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
        continueButton.SetActive(true);
    }

    //
    void EndDialogue()
    {
        scriptIsRunning = false;
        textBox.SetActive(false);
    }
}
