using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftWall : MonoBehaviour
{
   public Animator anim;
   [SerializeField] private GameObject lightHall;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Lamia.LamiaIsDead)
        {
            anim.SetTrigger("Lift");
            lightHall.SetActive(true);
        }
    }
}
