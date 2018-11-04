using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour {

    public ParticleSystem particle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        particle.Play();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        particle.Stop();
    }

}
