using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement2 : MonoBehaviour
{
    public bool isgrounded;
    Rigidbody2D rb2d;
    float vertical, horizontal;
    Animator anim;
    public float velocity =5f;
    string laststate ;
    public GameObject retry;
    BoxCollider2D bc2d;
    Touch touch;
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        bc2d = gameObject.GetComponent<BoxCollider2D>();
        isgrounded = true;
        laststate = "down";
        Touch touch = Input.GetTouch(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) touchmove(); 
            if (anim.GetNextAnimatorStateInfo(0).IsName("dead"))
        {
            
            Destroy(gameObject, 2f);
            retry.SetActive(true);
        }
        if (isgrounded && Mathf.Abs(rb2d.velocity.x) <0.1 && Mathf.Abs(rb2d.velocity.y) < 0.1)
        {
            rb2d.velocity = Vector2.zero;
            anim.SetBool("iscoll", true);
            transform.localScale = new Vector2(1, 1);
            anim.SetBool("isjumping", false);

        }
        else if (!isgrounded)
        {
            rb2d.velocity = new Vector2(horizontal*velocity,vertical*velocity);
            anim.SetBool("iscoll", false);
            anim.SetBool("isjumping", true);
            transform.localScale = new Vector2(-1,-1);
            bc2d.enabled = true;
        } 

        if ((Input.GetKeyDown(KeyCode.UpArrow)||up)&&isgrounded&&laststate!="up")
        {
            laststate = "up";
            isgrounded = false;
            vertical = 1;
            horizontal = 0;
            transform.localRotation = Quaternion.Euler(180, 0,0);
            bc2d.enabled = false;
        }
        if ((Input.GetKeyDown(KeyCode.DownArrow) || down) && isgrounded && laststate != "down")
        {
            laststate = "down";
            isgrounded = false;
            vertical = -1;
            horizontal = 0;
            transform.localRotation = Quaternion.Euler( 0, 0,0);
            bc2d.enabled = false;
        }
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || left) && isgrounded && laststate != "left")
        {
            laststate = "left";
            isgrounded = false;
            vertical = 0;
            horizontal = -1;
            transform.localRotation = Quaternion.Euler(0, 0,-90);
            bc2d.enabled = false;
        }
        if ((Input.GetKeyDown(KeyCode.RightArrow) || right) && isgrounded && laststate != "right")
        {
            laststate = "right";
            isgrounded = false;
            vertical = 0;
            horizontal = 1;
            transform.localRotation = Quaternion.Euler( 0, 0,90);
            bc2d.enabled = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            isgrounded = true;
        }
  
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
                if(collision.gameObject.tag == "floor")
        {
            isgrounded = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="portal")
        {
            velocity=0f;
            rb2d.angularVelocity = 20f;
            transform.position = new Vector2(transform.position.x-0.1f,transform.position.y-0.1f);
            anim.SetBool("isend", true);
        }
        if (collision.gameObject.tag == "enemy")
        {
            velocity = 0f;
            retry.SetActive(true);
            anim.SetBool("isdead",true);
        }
    }
    Vector2 postouch;
    Vector2 firstpos;
    public bool up, down, left, right;
    void touchmove()
    {
        
        Touch touch = Input.GetTouch(0);
 
            if (touch.phase == TouchPhase.Moved)
            {
                postouch = touch.position;
                Debug.Log("pos"+ postouch);
            }
            if (touch.phase == TouchPhase.Began)
            {
                firstpos= touch.position;
                postouch = firstpos;
                Debug.Log("firstpos" + firstpos);
            }
            if (firstpos.x-postouch.x<-250)
          
            {
                up = false;
                down = false;
                right = true;
                left = false;
            } else if (firstpos.x - postouch.x > 250)
            {
                up = false;
                down = false;
                right = false;
                left = true;
            }
            else if (firstpos.y - postouch.y > 250)
            {
                up = false;
                down = true;
                right = false;
                left = false;
            }
            else if (firstpos.y - postouch.y < -250)
            {
                up = true;
                down = false;
                right = false;
                left = false;
            }
        else
        {
            up = false;
            down = false;
            right = false;
            left = false;
        }
        }


    
}
