using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public Rigidbody2D rb;
    public int movespeed;
    public int jumppower;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    public int coins;
    const int left = 0, right = 1;
    private Animator anim;
    public GameObject bullet;
    private int facing;
    public bool moveLeft;
    public bool moveRight;
    public float startx, starty;
    public GameObject Blood;
    public AudioSource jump;
    

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facing = right;
        startx = transform.position.x;
        starty = transform.position.y;

    }

    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }



    void Update() {

    

        if (Input.GetKeyDown(KeyCode.LeftControl)) {
                var newBullet = Instantiate(bullet, transform.position, transform.rotation);
                var bulletScript = newBullet.GetComponent<Bullet>();
                bulletScript.direction = facing; 
            }

        
        if (moveLeft || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
            anim.SetBool("Walking", true);
            if (facing == right)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                facing = left;
            }

        } else if (moveRight || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
            anim.SetBool("Walking", true);
            if (facing == left)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                facing = right;
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
            jump.Play();
        } 
    }
        

        

    public void SuperJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumppower * 2);

        
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

