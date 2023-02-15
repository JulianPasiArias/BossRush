using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndergroundPathing : MonoBehaviour
{
     [SerializeField] Transform [] waypoints;

     public static bool LamiaIsUnderground = false;

    int waypointIndex = 0;

   public float speed;

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        LamiaIsUnderground = true;
    }
   
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);

        if(transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }
        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
