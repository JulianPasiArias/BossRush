using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float damping;
    public Transform target;
    public Vector3 offSet;
    private Vector3 velocity = Vector3.zero;

    
    
    void FixedUpdate()
    {
        Vector3 movePosition = target.position + offSet;
        transform.position = Vector3.SmoothDamp(transform.position,movePosition,ref velocity, damping);
    }
}
