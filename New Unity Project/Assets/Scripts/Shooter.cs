using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject pl;
    public Rigidbody2D shot;
    public int bulletNumber;

	// Use this for initialization
	void Start () {
        Rigidbody2D bulletInstance = Instantiate(shot, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
        bulletNumber = 1;
    }
	
	// Update is called once per frame
	void Update () {
		if (bulletNumber == 0)
        {
            Rigidbody2D bulletInstance = Instantiate(shot, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            bulletNumber = 1;
        }

        if(bulletNumber < 0 && bulletNumber != -50)
        {
            bulletNumber = 0;
        }
	}

    public void Shoot()
    {
        Rigidbody2D bulletInstance = Instantiate(shot, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
        bulletNumber = 1;
        Debug.Log("spawn");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            gameObject.tag = "SlimedFire";
            bulletNumber = -50;
        }

        if(collision.gameObject.tag == "Player" && gameObject.tag == "SlimedFire")
        {
            Destroy(gameObject);
            
        }
    }
}
