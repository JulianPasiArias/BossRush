using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    
    public Animator anim;

    public GameObject barrier,backround;

    
    

    private Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string>();
      
    }

    public void StartDialogue(Dialogue dialogue)
    {
        PlayerMovement.playerIsTalking = true;

        anim.SetBool("isOpen", true);

            nameText.text = dialogue.name;

            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;

        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines(); 
        StartCoroutine (TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        anim.SetBool("isOpen", false);
        PlayerMovement.playerIsTalking = false;
       
        NPC.dialogueIsOver = true;
        barrier.SetActive(false);
        backround.SetActive(false);
        

        
       
    }
}
