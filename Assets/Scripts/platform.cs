using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public float space;
    public float speed;
    float theta = 1.5708f;
 
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + space* Mathf.Sin(theta));
        theta = theta + speed;


    }

}
