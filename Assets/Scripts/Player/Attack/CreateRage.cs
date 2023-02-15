using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRage : MonoBehaviour
{
   public int minimumRage = 0;
   int currentRage;
   public RageBar ragebar;

    [SerializeField] private GameObject text;
   public static bool EyeAttackIsReady = false;

    void Start()
    {
        currentRage = minimumRage;
        ragebar.SetMinRage(minimumRage);
    }

    void Update()
    {
        if(EyeAttackIsReady && EyeAttackStun.EyeAttackDone)
        {
            currentRage = minimumRage;
            ragebar.SetRage(currentRage);
            EyeAttackStun.EyeAttackDone = false;
        }
    }
    
    public void IncreaseRage(int rageIncreased)
    {
        currentRage += rageIncreased;
        ragebar.SetRage(currentRage);

        if(currentRage >= 10)
        {
           EyeAttackIsReady = true;
           text.SetActive(true);
           Debug.Log("Eye Attack is Ready");

        }
        else
        {
            EyeAttackIsReady = false;
            text.SetActive(false);
        }
    }

    



}
