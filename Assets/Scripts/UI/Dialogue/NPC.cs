using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Dialogue dialogue;

    public bool inRange = false;

    public static bool  dialogueIsOver = false;

    [SerializeField] GameObject backround;

    
    public void TriggerDialogue()
    {
       if(!dialogueIsOver)
       {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
       }
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
          if(!dialogueIsOver)
          {
            backround.SetActive(true); 
            TriggerDialogue();
            inRange = true;
          } 
            

    }

   

    private void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }

    
}
