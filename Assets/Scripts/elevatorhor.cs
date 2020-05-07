using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorhor : MonoBehaviour
{

    public float space;
    public float speed;
    float theta = 1.5708f;


    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector2(transform.position.x + space * Mathf.Sin(theta), transform.position.y );
        theta = theta + speed;

    }
}
