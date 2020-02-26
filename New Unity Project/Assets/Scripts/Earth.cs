using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            transform.gameObject.tag = "SlimedEarth";

        }

        if (transform.gameObject.tag == "SlimeEarth")
        {
            if (collision.gameObject.name == "Slime" && gameObject.tag == "SlimedEarth")
            {
                Destroy(gameObject);
            }
        }

    }
}
