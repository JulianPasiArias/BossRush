using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManagement : MonoBehaviour
{
    public GameObject virtualCamera;
    

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player") && !col.isTrigger)
        {
            virtualCamera.SetActive(true);
        }
    }
     void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player") && !col.isTrigger)
        {
            virtualCamera.SetActive(false);
        }
    }
}
