using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveLevel(int level)
    {
        PlayerPrefs.SetInt("farthestLevel", level);
    }
    
    public int LoadLevel()
    {
        return PlayerPrefs.GetInt("farthestLevel");
    }
}
