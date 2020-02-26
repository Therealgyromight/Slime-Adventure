using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldNav : MonoBehaviour {

    public Vector2 level1pos = new Vector2(3, 3);
    public Vector2 level2pos = new Vector2(2, 2);
    public Vector2 level3pos = new Vector2(4, 4);
    public Vector2 level4pos = new Vector2(1, 1);
    public Vector2 level5pos = new Vector2(2, 2);
    
    public GameObject player;
    public int Level;


    // Use this for initialization
    void Start () {
        
        PlayerPrefs.GetInt("Level");
        player.transform.position = level1pos;
        Level = 1;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }

        if(Level == 1)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Level = 2;
                player.transform.position = level2pos;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(3);
            }
        }

        if (Level == 2)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Level = 3;
                player.transform.position = level3pos;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Level = 1;
                player.transform.position = level1pos;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(4);
            }
        }

        if (Level == 3)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Level = 4;
                player.transform.position = level4pos;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Level = 2;
                player.transform.position = level2pos;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(5);
            }
        }

        if (Level == 4)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Level = 5;
                player.transform.position = level5pos;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Level = 3;
                player.transform.position = level3pos;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(6);
            }
        }

        if (Level == 5)
        {
            

            if (Input.GetKeyDown(KeyCode.A))
            {
                Level = 4;
                player.transform.position = level4pos;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(7);
            }
        }
    }
}
