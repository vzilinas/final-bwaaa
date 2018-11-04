﻿
using UnityEngine;

public class CrossProjectileController : MonoBehaviour {

    public AudioClip crossThrowAudio;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            return;
        }

        AudioSource.PlayClipAtPoint(crossThrowAudio, transform.position);
        Destroy(gameObject);
    }
}
