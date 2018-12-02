using UnityEngine;

public class MonsterHealthController : MonoBehaviour
{
    public AudioClip deathAudio;
    public int maxHealth;
    public bool isSpawnerOnDeath;
    private AudioSource audioSource;
    private int currentHealth;
    public bool isDying = false;

    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0 && isDying == false)
        {
            currentHealth = 0;
            isDying = true;
            Die();
        }
    }

    void Die()
    {
        HighScore.score += 100;
        if (isSpawnerOnDeath)
        {
            HighScore.score += 1000;
            AudioSource.PlayClipAtPoint(deathAudio, transform.position);
            GetComponent<DeathAnimation>().isDead = true;
        }
        else
        {
            AudioSource.PlayClipAtPoint(deathAudio, transform.position);
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PlayerAttack")
        {
            currentHealth--;
        }
    }
}
