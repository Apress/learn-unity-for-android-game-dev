using UnityEngine;

using System.Collections;



public class Hazards : MonoBehaviour
{
    private Player player;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.transform.position = new Vector2(-6, 8);
        }
    }
}
