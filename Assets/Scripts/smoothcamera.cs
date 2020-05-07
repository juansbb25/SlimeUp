using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothcamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float offsetspeed = 0.125f;
    void Start()
    {
        
    }
    
    private void LateUpdate()
    {
        Vector3 desiredposition = player.position + offset;
        Vector3 smoothposition = Vector3.Lerp(transform.position, desiredposition, offsetspeed);
        transform.position = smoothposition;

    }
}
