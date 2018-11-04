using UnityEngine;

public class ExorcistController : MonoBehaviour
{
    public AudioClip exorcistDamagedAudio;
    private AudioSource audioSource;
    public GameObject bulletPrefab;
    public float projectileSpawnDistance = 5;
    public float projectileVelocity = 10;
    public int maxHealth;
    private int currentHealth;
    private Vector3 playerPos;
    private Vector3 playerDirection;
    public int pillAmount = 0;

    //public Sprite zombieSprite;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameObject.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
            {
                return;
            }
            Fire();
        }

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

    void Fire()
    {
        playerPos = gameObject.transform.position;
        playerDirection = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
        Vector3 spawnPos = playerPos + playerDirection * projectileSpawnDistance;

        var bullet = Instantiate(
            bulletPrefab,
            spawnPos,
            Quaternion.Euler(new Vector3(0, 0, 1)));

        bullet.GetComponent<Rigidbody2D>().velocity = playerDirection * projectileVelocity;

        Destroy(bullet, 1.0f);
    }

    private void Die()
    {
        Destroy(gameObject);
        //gameObject.GetComponent<SpriteRenderer>().sprite = zombieSprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(exorcistDamagedAudio, transform.position);
            currentHealth--;
        }

        if (collision.gameObject.tag == "Item")
        {
            Destroy(collision.gameObject);
            pillAmount++;
        }
    }
}