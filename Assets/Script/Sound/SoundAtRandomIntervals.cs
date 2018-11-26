using System.Collections;
using UnityEngine;

class SoundAtRandomIntervals : MonoBehaviour
{
    public AudioClip sound;
    private AudioSource audioSource;

    void Start()
    {
        StartCoroutine(PlaySound());
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(3f, 8f));

        audioSource.PlayOneShot(sound);

        yield return new WaitForSeconds(sound.length);
        StartCoroutine(PlaySound());
    }
}
