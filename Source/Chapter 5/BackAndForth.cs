using UnityEngine;

using System.Collections;



public class BackAndForth : MonoBehaviour
{

    public double amounttomove;
    public float speed;
    private float startx;
    private int direction;

    // Use this for initialization
    void Start()
    {
        direction = 0;
        startx = gameObject.transform.position.x;

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
    }
}        
