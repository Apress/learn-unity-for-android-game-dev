using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public int direction;
    private int timeLeft;
    public GameObject Blood;
    // Use this for initialization
    void Start()
    {
        timeLeft = 100;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = timeLeft - 1;
        if (timeLeft < 1)
        {
            Destroy(gameObject);
        }
        if (direction == 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - speed, gameObject.transform.position.y);
        }
        else if (direction == 1)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + speed, gameObject.transform.position.y);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Instantiate(Blood, transform.position, transform.rotation);
        }
        else if (other.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
        else
        {
            Destroy(gameObject);

        }
    }
}