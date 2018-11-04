using UnityEngine;

public class ZombieController : MonoBehaviour {

    private int currentHealth = 2;
    private int maxHealth = 2;

    void Start () {
		
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
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "PlayerAttack")
        {
            currentHealth--;
        }
    }
}
