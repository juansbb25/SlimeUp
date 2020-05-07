using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class goal : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Animator anim;
    public string nextlevel;
    bool iscoll;
    public int levelsunlock;
    Player player;
    Text text;
    CircleCollider2D cc2d;
    SpriteRenderer sprite;
    void Start()
    {
        player = FindObjectOfType<Player>();
        player.LoadPlayer();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = GameObject.FindGameObjectWithTag("player").GetComponent<Animator>();
        iscoll = false;
        text = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        cc2d = gameObject.GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        cc2d.enabled = false;
        sprite.color = Color.black;
    }

    public string gems;
    // Update is called once per frame
    void Update()
    {
        gems = text.text;

        if(gems == "3")
        {
            rb2d.angularVelocity = 30f;
            cc2d.enabled = true;
            sprite.color = Color.white;

        }
        
        if (anim.GetNextAnimatorStateInfo(0).IsName("move")&&iscoll)
        {

 
            SceneManager.LoadScene(nextlevel);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "player")
        {
            if (player.unlock<levelsunlock)
            {
                player.unlock = levelsunlock;
                player.SavePlayer();
            }

            iscoll = true;
        }
    }


}
