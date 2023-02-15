using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheckpoint : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log("CheckpointSaved");
           GameManager.instance.CheckpointPosition(col.transform.position);
           
        }
    }

   

}
