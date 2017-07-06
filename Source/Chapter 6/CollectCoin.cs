using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour {

    // Use this for initialization
    public GameObject Sparkle;
    private Player player;
    public AudioSource bling;

    void Start () {
        player = FindObjectOfType<Player>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            bling.Play();
            player.coins++;
            Instantiate(Sparkle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
