using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Rigidbody2D rb;
    public int movespeed;
    public int jumppower;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    public int coins;
    private Animator anim;
    private int facing;
    public bool moveLeft;
    public bool moveRight;
    public float startx;
    public float starty;
    public GameObject Blood;


    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facing = 1;
        startx = transform.position.x;
        starty = transform.position.y;

    }

    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }



    void Update() {

        
        if (moveLeft || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
            anim.SetBool("Walking", true);
            if (facing == 1)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                facing = 0;
            }

        } else if (moveRight || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
            anim.SetBool("Walking", true);
            if (facing == 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                facing = 1;
            }

        } else
        {
            anim.SetBool("Walking", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Jump() {

        if (onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumppower);
        }

        }

    public void Death()
    {
            StartCoroutine("respawndelay");
     
    }

    public IEnumerator respawndelay()
    {
        Instantiate(Blood, transform.position, transform.rotation);
        enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1);
        transform.position = new Vector2(startx, starty);
        GetComponent<Renderer>().enabled = true;
        enabled = true;
        
    }
}
