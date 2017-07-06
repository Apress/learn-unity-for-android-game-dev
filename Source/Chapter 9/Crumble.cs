using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crumble : MonoBehaviour {
    private Player player;
    private Rigidbody2D rb;
    public int timeToCollapse;
    private int timeLeft;
    public int timeToRestore;
    private int restoreTime;
    private float startY;
    private float startX;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        startX = transform.position.x;
        startY = transform.position.y;
        timeLeft = -70;
    }
	
	// Update is called once per frame
	void Update () {
		if (timeLeft > -70)
        {
            timeLeft = timeLeft - 1;
        }
        if (timeLeft == 0) 
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        if (timeLeft == -62)
        {
            GetComponent<Renderer>().enabled = false;
            restoreTime = timeToRestore;
        }
        if (restoreTime > 0)
        {
            restoreTime = restoreTime - 1;
        }
        if (restoreTime == 2)
        {
            transform.position = new Vector3(startX, startY);
            transform.rotation = Quaternion.identity;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Renderer>().enabled = true;
        }
        
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            timeLeft = timeToCollapse;
        }
    }


}
