using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puas : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Transform pos1, pos2;
    Vector3 nextpos;
    public float initspeed;
    float speed;
    void Start()
    {
        initspeed = 0.03f;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        transform.position = pos1.position;
        nextpos = pos2.position;
        speed = initspeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.position == pos1.position)
        {
            nextpos = pos2.position;
            speed = initspeed;
        }

        if (transform.position == pos2.position)
        {
            nextpos = pos1.position;
            speed = speed*2;

        }


        transform.position = Vector3.MoveTowards(transform.position, nextpos, speed);
    }
}
