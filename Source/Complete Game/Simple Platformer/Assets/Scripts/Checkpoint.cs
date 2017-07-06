using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    private Player player;
    

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.startx = this.transform.position.x;
            player.starty = this.transform.position.y;
        }
    }


}