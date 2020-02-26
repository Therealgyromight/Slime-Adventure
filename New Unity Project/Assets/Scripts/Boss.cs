using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public GameObject player;
    public Vector2 pPosition;
    public int life;

    // Use this for initialization
    void Start () {
        life = 6;
        PlayerPrefs.SetInt("Boss", 0);
	}
	
	// Update is called once per frame
	void Update () {
        pPosition = player.transform.position;

        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), pPosition, 3 * Time.deltaTime);
        

        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle + -90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 3);


        if(life == 0)
        {
            PlayerPrefs.SetInt("Boss", 1);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            life--;

        }

        

    }
}
