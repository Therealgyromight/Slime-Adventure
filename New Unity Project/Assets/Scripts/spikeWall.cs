using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeWall : MonoBehaviour {

    public Vector2 startpos, endpos;
    public bool end;

    // Use this for initialization
    void Start()
    {
        startpos = transform.position;
        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (end == false)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), endpos, 4 * Time.deltaTime);
        }

        if (end == true)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), startpos, 4 * Time.deltaTime);
        }

        Vector3 v3 = transform.position;
        Vector2 v2 = v3;
        if (v2 == endpos)
        {
            end = true;
        }
        if (v2 == startpos)
        {
            end = false;
        }
    }
}
