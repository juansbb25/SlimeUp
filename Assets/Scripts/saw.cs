using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Transform pos1, pos2, pos3, pos4;
    Vector3 nextpos;
    public float speed;
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        transform.position = pos1.position;
        nextpos = pos2.position;
        speed = 0.1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.angularVelocity = 100f;

        if (transform.position == pos1.position)  
        {
            nextpos = pos2.position;
        }

        if (transform.position == pos2.position)
        {
            nextpos = pos3.position;
        }

        if (transform.position == pos3.position)
        {
            nextpos = pos4.position;
        }

        if (transform.position == pos4.position)
        {
            nextpos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextpos, speed);
    }
}
