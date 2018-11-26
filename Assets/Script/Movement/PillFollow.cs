using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillFollow : MonoBehaviour {

    public float speed;
    private Collider2D col;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(col != null)
        {
            if (col.tag == "Player")
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, col.transform.position, step);
            }
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        col = collision;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        col = null;
    }
}
