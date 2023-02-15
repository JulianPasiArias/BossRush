using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
  

   
    void Update()
    {
         Physics2D.IgnoreLayerCollision(6,10);
    }
}
