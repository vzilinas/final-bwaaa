using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExorcistController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        var y = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var x = Input.GetAxis("Vertical") * Time.deltaTime * 150.0f;

        transform.Translate(0, x, 0);
        transform.Translate(y, 0, 0);
    }
}
