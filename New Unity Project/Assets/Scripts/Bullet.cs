using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Rigidbody2D rb, player;
    public Collider2D bl, pl;
    public GameObject Player;
	// Use this for initialization
	void Start () {
        //rb.AddForce(transform.right * 50f);
        
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.up * 1f);
    }
    // Collisions to despawn bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Fire" || collision.gameObject.tag == "Air" || collision.gameObject.tag == "Water" || collision.gameObject.tag == "Earth" || collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Lever" || collision.gameObject.tag == "Spike" || collision.gameObject.tag == "LifeGate" || collision.gameObject.tag == "Boss")
        {
            PlayerPrefs.SetInt("Bullet", 0);
            Destroy(gameObject);
        }
        // Test to prevent bullet colliding with players, unused, now done through collision layers
        if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(Player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

    }

    
}
