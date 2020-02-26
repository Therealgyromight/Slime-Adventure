using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour {

    public GameObject boss;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("Boss") == 1)
        {
            Destroy(gameObject);
        }
	}
}
