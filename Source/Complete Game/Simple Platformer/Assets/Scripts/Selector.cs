using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector : MonoBehaviour {

    public bool moveLeft;
    public bool moveRight;
    public string levelChoice;
    public int farthestLevel;

    void Start()
    {
        PlayerPrefs.GetInt("farthestLevel");
    }

   


    void Update()
    {


        if (transform.position.x > -5 && (moveLeft || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            transform.position = new Vector2(transform.position.x - 6, transform.position.y);
            moveLeft = false;

        }
        else if (transform.position.x < 7 && (moveRight || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            transform.position = new Vector2(transform.position.x + 6, transform.position.y);
            moveRight = false;
        }
        

        if (Input.GetKey(KeyCode.Space))
        {
            Select();
        }
    }

    public void Select()
    {
        if (levelChoice != "none")
        {
            SceneManager.LoadScene(levelChoice);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "on")
        {
            levelChoice = other.name;
        } else
        {
            levelChoice = "none";
        }

    }


    

    
}
