using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().GetComponent<AudioSource>().enabled = false;
        }
    }
}
