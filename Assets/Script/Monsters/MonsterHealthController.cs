using UnityEngine;

public class MonsterHealthController : MonoBehaviour {

    public AudioClip deathAudio;
    private AudioSource audioSource;
    public int maxHealth = 3;
    private int currentHealth;

    void Start () {
        currentHealth = maxHealth;
    }
    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void Die()
    {
        AudioSource.PlayClipAtPoint(deathAudio, transform.position);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PlayerAttack")
        {
            currentHealth--;
        }
    }
}
