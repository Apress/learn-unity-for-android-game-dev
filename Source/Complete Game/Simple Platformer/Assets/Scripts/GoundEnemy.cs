using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoundEnemy : MonoBehaviour
{
    private Player player;
    private int facing;
    public int jumpHeight;
    public float enemySpeed;
    private bool chaseIsOn;
    public int attackRange;
    public Transform groundCheck;
    public Rigidbody2D rb;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    public Transform enemySightStart;
    public Transform enemySightEnd;
    public Transform enemySightEnd2;
    private float startX;
    public double amountToMove;

    void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        startX = gameObject.transform.position.x;
        facing = 3;
    }

    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        Debug.DrawLine(enemySightStart.position, enemySightEnd.position, Color.red);
        Debug.DrawLine(enemySightStart.position, enemySightEnd2.position, Color.green);
    }




    void Update()
    {

        if (gameObject.transform.position.x - player.transform.position.x < attackRange && gameObject.transform.position.x - player.transform.position.x > -attackRange && chaseIsOn == false)
        {
            chaseIsOn = true;
        }
        if (gameObject.transform.position.x - player.transform.position.x > attackRange || gameObject.transform.position.x - player.transform.position.x < -attackRange && chaseIsOn == true)
        {
            if (chaseIsOn)
            {
                startX = gameObject.transform.position.x;
            }
            chaseIsOn = false;
        }


        if (chaseIsOn)
        {
            Pursuit();
        }
        else
        {
            Patrol();
        }
    }


    private void Patrol()
    {
        if (facing == 3)
        {
            facing = 0;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (gameObject.transform.position.x < startX + amountToMove && facing == 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + enemySpeed / 2, gameObject.transform.position.y);

        }
        else if (gameObject.transform.position.x >= startX + amountToMove && facing == 0)
        {
            facing = 1;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (gameObject.transform.position.x > startX && facing == 1)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - enemySpeed / 2, gameObject.transform.position.y);
        }
        else if (gameObject.transform.position.x <= startX && facing == 1)
        {
            facing = 0;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (Physics2D.Linecast(enemySightStart.position, enemySightEnd2.position, whatIsGround) == false || Physics2D.Linecast(enemySightStart.position, enemySightEnd.position, whatIsGround))
        {
            if (facing == 1)
            {
                facing = 0;
                transform.localScale = new Vector3(-1f, 1f, 1f);

            }
            else
            {
                facing = 1;
                transform.localScale = new Vector3(1f, 1f, 1f);

            }
        }
    }

    private void Pursuit()
    {

        if (Physics2D.Linecast(enemySightStart.position, enemySightEnd.position, whatIsGround) || Physics2D.Linecast(enemySightStart.position, enemySightEnd2.position, whatIsGround) == false)
        {
            Jump();
        }


        if (gameObject.transform.position.x > player.transform.position.x)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - enemySpeed, gameObject.transform.position.y);
            if (facing == 0 || facing == 3)
            {
                facing = 1;
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }

        if (gameObject.transform.position.x < player.transform.position.x)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + enemySpeed, gameObject.transform.position.y);
            if (facing == 1 || facing == 3)
            {
                facing = 0;
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }

    private void Jump()
    {

        if (onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}
