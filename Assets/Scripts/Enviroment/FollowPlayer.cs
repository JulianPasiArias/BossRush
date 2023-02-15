using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player"))
        {
            transform.up = player.transform.position - transform.position;
        }
        
      
    }
}
