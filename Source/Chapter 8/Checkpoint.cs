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
            player.startx = transform.position.x;
            player.starty = transform.position.y;
        }
    }


}
