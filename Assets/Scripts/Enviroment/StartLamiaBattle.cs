using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLamiaBattle : MonoBehaviour
{
    public static bool LamiaBattleStarted = false;
  
    [SerializeField] GameObject LamiaHP,CrystalSpawner,blood,nameOfBoss,rageBar;

    public AudioSource audioS;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            nameOfBoss.SetActive(true);
            rageBar.SetActive(true);
            LamiaBattleStarted = true;
            LamiaHP.SetActive(true);
            CrystalSpawner.SetActive(true);
            blood.SetActive(true);
            audioS.Play();
            
           
            Enemy.firstLilitaIsDead = true;
            SecondPhase.SecondPhaseDone = true;
            ThirdPhase.ThirdPhaseDone = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
