using UnityEngine;

public class ZombieController : MonoBehaviour {

    public AudioClip zombieDeathAudio;
    private AudioSource audioSource;
    public int maxHealth = 2;
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
        AudioSource.PlayClipAtPoint(zombieDeathAudio, transform.position);
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
