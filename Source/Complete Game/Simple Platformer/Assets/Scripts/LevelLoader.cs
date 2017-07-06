using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

    public int thisLevel;
    private Selector selector;

    void Start () {
        selector = FindObjectOfType<Selector>();
        
    }
	
	
	void Update () {
		if (selector.farthestLevel < thisLevel) {
            this.tag = "off";
            GetComponent<Renderer>().enabled = false;
        } else
        {
            this.tag = "on";
            GetComponent<Renderer>().enabled = true;
        }
    }
}
