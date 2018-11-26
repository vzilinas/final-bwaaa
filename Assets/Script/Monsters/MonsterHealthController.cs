using UnityEngine;

public class MonsterHealthController : MonoBehaviour
{
    public GameObject zombie;
    public AudioClip deathAudio;
    public int maxHealth;
    public bool isGraveRobber;
    private AudioSource audioSource;
    private int currentHealth;

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

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void Die()
    {
        if (isGraveRobber)
        {
            SpawnZombiesOnDeath();
        }
        AudioSource.PlayClipAtPoint(deathAudio, transform.position);
        Destroy(gameObject);
    }
    void SpawnZombiesOnDeath()
    {
        Vector3 spawnPosition1 =
            new Vector3(gameObject.transform.position.x - 5, gameObject.transform.position.y, 0f);
        Vector3 spawnPosition2 =
            new Vector3(gameObject.transform.position.x + 5, gameObject.transform.position.y, 0f);
        Instantiate(zombie, spawnPosition2, new Quaternion(0f, 0f, 0f, 0f));
        Instantiate(zombie, spawnPosition1, new Quaternion(0f, 0f, 0f, 0f));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PlayerAttack")
        {
            currentHealth--;
        }
    }
}
