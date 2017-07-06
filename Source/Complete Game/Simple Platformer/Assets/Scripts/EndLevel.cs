using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {
    public string nextLevel;
    public int levelValue;
    
    
    void Start()
    {
        
    }

    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SaveLevel(levelValue);
            SceneManager.LoadScene(nextLevel);
           
        }
    }

    public void SaveLevel(int level)
    {
        PlayerPrefs.SetInt("farthestLevel", level);
    }
}
