using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{

    public double amounttomove;
    public float speed;
    private float startx;
    private float starty;
    public int direction;
    private Player player;
    
    // Use this for initialization
    void Start()
    {
        
        startx = gameObject.transform.position.x;
        starty = gameObject.transform.position.y;
        player = FindObjectOfType<Player>();

    }

    // Update is called once per frame

    void Update()
    {
        if (gameObject.transform.position.x < startx + amounttomove && direction == 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + speed, gameObject.transform.position.y);

        }
        else if (gameObject.transform.position.x >= startx + amounttomove && direction == 0)
        {
            direction = 1;
        }
        else if (gameObject.transform.position.x > startx && direction == 1)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - speed, gameObject.transform.position.y);
        }
        else if (gameObject.transform.position.x <= startx && direction == 1)
        {
            direction = 0;
        }


        if (gameObject.transform.position.y < starty + amounttomove && direction == 3)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + speed);

        }
        else if (gameObject.transform.position.y >= starty + amounttomove && direction == 3)
        {
            direction = 2;
        }
        else if (gameObject.transform.position.y > starty && direction == 2)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - speed);
        }
        else if (gameObject.transform.position.y <= starty && direction == 2)
        {
            direction = 3;
        }


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.parent = gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.parent = null;
        }
    }
}