using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteHit : MonoBehaviour {

    public int hit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Slimed")
        {
            hit = 1;
        }
        else
        {
            hit = 0;
        }
    }
}
