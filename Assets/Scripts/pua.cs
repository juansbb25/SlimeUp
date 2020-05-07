using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pua : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb2d;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetNextAnimatorStateInfo(0).IsName("fall"))
        {
            rb2d.gravityScale = 7f;
            Destroy(gameObject, 2f);
        } else rb2d.gravityScale = 0;
    }
}
