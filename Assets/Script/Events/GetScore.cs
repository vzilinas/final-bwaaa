using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var score = HighScore.score - (500 * BuffManager.debuffCounter) + (100 * BuffManager.buffCounter);
        score = BuffManager.highScoreBuff ? Convert.ToInt32(score * 1.2) : score;
        score = BuffManager.highScoreDebuff ? Convert.ToInt32(score * 0.8) : score;
        
        gameObject.GetComponent<Text>().text = score.ToString();
        HighScore.score = 0;
	}
}
