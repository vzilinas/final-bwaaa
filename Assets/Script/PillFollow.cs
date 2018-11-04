using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillFollow : MonoBehaviour {

    public float speed;
    private Collider2D collider;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(collider != null)
        {
            if (collider.tag == "Player")
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, collider.transform.position, step);
            }
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collider = collision;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collider = null;
    }
}
