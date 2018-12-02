using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Text>().text = HighScore.score.ToString();
        HighScore.score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
