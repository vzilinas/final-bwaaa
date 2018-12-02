using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(GameObject.Find("Music"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
