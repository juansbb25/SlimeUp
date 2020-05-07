using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class movement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator anim;
    bool isjumping;
    bool coll;
    Animation currentanim;
    public GameObject retry;
    CapsuleCollider2D cc2d;
    public Canvas cvs;
    // start
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        currentanim = gameObject.GetComponent<Animation>();
        cc2d = gameObject.GetComponent<CapsuleCollider2D>();
    }
    public bool p;
    // Update
    void Update()
    {
        p = anim.GetCurrentAnimatorStateInfo(0).IsName("generate");
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("generate"))
        {
            move();
            rb2d.gravityScale = 11.15f;
        }
        else
        {
            rb2d.gravityScale = 0f;
            rb2d.velocity = new Vector2(0f, 0f); ;
        }
        
        if (rb2d.velocity.y < 0f)
        {
            anim.SetBool("isfall", true);
            anim.SetBool("isjumping", false);
            
        }else anim.SetBool("isfall", false);
        //salto
        if ((Input.GetKeyDown(KeyCode.Space)||booljump) && coll && rb2d.velocity.y == 0)
        {

            jump(this.jumpforce*2f);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("eatleftr"))
        {
            anim.SetBool("iseatinglat", false);
        }

     
    }

    //Salto del personaje
    float jumpforce=20f;
    void jump(float jumpforce)
    {
   
        
        isjumping = true;
        rb2d.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
        anim.SetBool("isjumping", true);
        anim.SetBool("iscoll", false);
        isjumping = true;


    }
    // colisiones 
    void OnCollisionEnter2D(Collision2D collision)
    {
        //piso
        if (collision.gameObject.tag == "floor")
        {
            this.coll = true;
            anim.SetBool("iscoll", true);
            anim.SetBool("isfall", false);
        }
        //teletransporte
        if (collision.gameObject.tag == "portal")
        {
            anim.SetBool("isportal", true);
            this.coll = true;
            anim.SetBool("iscoll", true);
            anim.SetBool("isfall", false);
            anim.Play("generate");
        }
        //resorte
        if (collision.gameObject.tag == "spring")
        {
            jump(this.jumpforce * 2f);
        }
        // muerte del personaje
        if (collision.gameObject.tag == "lava"|| collision.gameObject.tag == "enemy")
        {
            retry.SetActive(true);
            rb2d.isKinematic = true;
            cc2d.enabled = false;
            rb2d.velocity = new Vector2(0f, 0f);
            anim.SetBool("isdead", true);
            cvs.enabled = false;

        }
        //plataforma movil
        if (collision.gameObject.tag == "elevator")
        {
            this.coll = true;
            anim.SetBool("iscoll", true);
            anim.SetBool("isfall", false);
            gameObject.transform.parent = collision.transform;

        }
        


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //comer lateral
        if (collision.gameObject.tag == "food")
        {
            anim.SetBool("iseatinglat", true);
            bool coll = collision.enabled;
            
        }
 
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            this.coll = true;
            anim.SetBool("iscoll", true);
            anim.SetBool("isfall", false);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            this.coll = false;
        }
        if (collision.gameObject.tag == "elevator")
        {
            this.coll = true;
            anim.SetBool("iscoll", true);
            anim.SetBool("isfall", false);
            gameObject.transform.parent = null;

        }
    }
    
    // movimiento principal del personaje
    private void move()
    {
       // movimiento lateral en el piso 
        if ( (Input.GetKey(KeyCode.LeftArrow)||isleft) && coll &&rb2d.velocity.y == 0)
        {
            rb2d.velocity = new Vector2(-7f, rb2d.velocity.y);
            anim.SetBool("ismove", true);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if ((Input.GetKey(KeyCode.RightArrow) || isright) && coll && rb2d.velocity.y == 0)
        {
            rb2d.velocity = new Vector2(7f, rb2d.velocity.y);
            anim.SetBool("ismove", true);
            gameObject.transform.localScale = new Vector3(-1, 1, 1) ;
        }
        //animacion cuando el eje x descansa
        if (Mathf.Abs( rb2d.velocity.x) < 6)
        {
            anim.SetBool("ismove", false);
            anim.SetBool("isimpulse", false);
        }

        //movimiento lateral en el aire
        if ((Input.GetKey(KeyCode.LeftArrow) || isleft) && !coll && isjumping && rb2d.velocity.x >-1f)
        {
            
            rb2d.AddForce(transform.right * -8f, ForceMode2D.Impulse);
            anim.SetBool("isimpulse", true);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            isjumping = false;
        }
        
        if ((Input.GetKey(KeyCode.RightArrow) || isright)&& !coll && isjumping && rb2d.velocity.x <1f)
        {
            rb2d.AddForce(transform.right * 8f, ForceMode2D.Impulse);
            anim.SetBool("isimpulse", true);
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            isjumping = false;
        }
        // animacion del movimiento lateral en el aire
        if (Mathf.Abs(rb2d.velocity.x) > 1f && !coll && isjumping) anim.SetBool("isimpulse", true);
        if (!coll && Mathf.Abs(rb2d.velocity.x)>4)
        {
            anim.SetBool("isimpulse", true);
        }
        if (rb2d.velocity.x == 0||coll)
        {
            anim.SetBool("isimpulse", false);
        }

    }
    public bool isright, isleft, booljump;
    public void movedirection(int direction)
    {
        if (direction == 1)
        {
            isright = true;
            isleft = false;

        }
        if (direction == 0)
        {
            isleft = false;
            isright = false;


        }
        if (direction == -1)
        {
            isright = false;
            isleft = true;


        }
        if (direction == 2)
        {
            booljump=true;


        }
        if (direction == 3)
        {
            booljump = false;


        }
    }
}
