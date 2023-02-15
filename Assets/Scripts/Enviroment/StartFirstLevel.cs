using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFirstLevel : MonoBehaviour
{
    public GameObject barrier, boss, UI,crystals;

  
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            barrier.SetActive(true);
            boss.SetActive(true);
            UI.SetActive(true);
            crystals.SetActive(true);
            Destroy(gameObject);

        }
    }
}
