using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFirstLevel : MonoBehaviour
{
    public GameObject barrier, boss, UI,crystals,nameOfBoss;

  
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
           nameOfBoss.SetActive(true);
            barrier.SetActive(true);
            boss.SetActive(true);
            UI.SetActive(true);
            crystals.SetActive(true);
            Destroy(gameObject);

        }
    }
}
