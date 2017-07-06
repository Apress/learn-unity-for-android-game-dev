using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text coins;
    private Player player;

    // Use this for initialization
    void Start()
    {
        coins = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        coins.text = "Coins: " + player.coins;
    }
}
