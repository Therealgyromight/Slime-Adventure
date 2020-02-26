using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGate : MonoBehaviour {

    public GameObject Gate;
    public int healthTaken;
    public Sprite off;
    public SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        healthTaken = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(healthTaken > 1)
        {
            Destroy(Gate);
            sprite.sprite = off;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && healthTaken < 2)
        {
            healthTaken++;
        }

        if (collision.gameObject.tag == "Ball")
        {
            healthTaken++;
        }
    }
}
