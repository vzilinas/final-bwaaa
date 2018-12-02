using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadVisibility : MonoBehaviour {
    public GameObject panel;
    public bool panelVisible = false;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if(!panelVisible && BuffManager.visibilityDebuff)
        {
            panel.SetActive(true);
            panelVisible = true;
        }
	}
}
