using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float speed=0.003f;
    void Update()
    {
        gameObject.transform.position = new Vector2(transform.position.x, transform.position.y+speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            speed = 0f;
        }
    }
}
