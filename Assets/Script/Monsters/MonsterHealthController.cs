using UnityEngine;

public class MonsterHealthController : MonoBehaviour
{
    public GameObject spawnlingOnDeath;
    public GameObject objectLeftOnDeath;
    public AudioClip deathAudio;
    public int maxHealth;
    public bool isSpawnerOnDeath;
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
        HighScore.score += 100;
        if (isSpawnerOnDeath)
        {
            SpawnZombiesOnDeath();
            LeaveCorpseOnGround();
        }
        AudioSource.PlayClipAtPoint(deathAudio, transform.position);
        Destroy(gameObject);
    }

    void LeaveCorpseOnGround()
    {
        var deathPosition = new Vector3(
         gameObject.transform.position.x,
         gameObject.transform.position.y,
         0f);
        Instantiate(objectLeftOnDeath, deathPosition, new Quaternion(0f, 0f, 0f, 0f));
    }
    void SpawnZombiesOnDeath()
    {
        Vector3 spawnPosition1 =
            new Vector3(gameObject.transform.position.x - 5, gameObject.transform.position.y, 0f);
        Vector3 spawnPosition2 =
            new Vector3(gameObject.transform.position.x + 5, gameObject.transform.position.y, 0f);
        Instantiate(spawnlingOnDeath, spawnPosition2, new Quaternion(0f, 0f, 0f, 0f));
        Instantiate(spawnlingOnDeath, spawnPosition1, new Quaternion(0f, 0f, 0f, 0f));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PlayerAttack")
        {
            currentHealth--;
        }
    }
}
