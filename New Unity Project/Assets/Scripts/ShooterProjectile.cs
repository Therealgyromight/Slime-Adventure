using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterProjectile : MonoBehaviour {

    public GameObject pl;
    public Vector2 pPosition;
    public Shooter other;
    public GameObject shooter;

	// Use this for initialization
	void Start () {
        pPosition = pl.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), pPosition, 3 * Time.deltaTime);
        Vector3 v3 = transform.position;
        Vector2 v2 = v3;
        if(v2 == pPosition)
        {
            other.bulletNumber--;
            Destroy(gameObject);
            
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            
            other.bulletNumber--;
        }
        if(coll.gameObject.tag == "Ground" || coll.gameObject.tag == "Wall" || coll.gameObject.tag == "LifeGate")
        {
            Destroy(gameObject);
            other.bulletNumber--;
        }
    }
}
