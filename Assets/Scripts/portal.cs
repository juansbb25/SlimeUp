using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Transform port;
    public Transform player;
    public int levelsunlock;
    levelselector levelselector;
    Vector2 move;
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        move = port.position;

    }

    // Update is called once per frame
    void Update()
    {
        rb2d.angularVelocity = 50f;
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {

            player.transform.position = move;
        }
    }
}
