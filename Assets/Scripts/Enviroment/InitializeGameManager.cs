using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InitializeGameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameManager,checkPoints;

    void Awake()
    {
       
        if(!FindObjectOfType<GameManager>())
        {
            Instantiate(gameManager,transform.position,Quaternion.identity);
           
            if(!GameObject.Find("CheckPoints"))
            {
                Instantiate(checkPoints,transform.position,Quaternion.identity);
            }
            
        } 
        
       
    }

}
