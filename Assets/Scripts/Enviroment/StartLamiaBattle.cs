using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLamiaBattle : MonoBehaviour
{
    public static bool LamiaBattleStarted = false;
  
    [SerializeField] GameObject LamiaHP,CrystalSpawner,blood;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            LamiaBattleStarted = true;
            LamiaHP.SetActive(true);
            CrystalSpawner.SetActive(true);
            blood.SetActive(true);
           
            Enemy.firstLilitaIsDead = true;
            SecondPhase.SecondPhaseDone = true;
            ThirdPhase.ThirdPhaseDone = true;
        }
    }
}
