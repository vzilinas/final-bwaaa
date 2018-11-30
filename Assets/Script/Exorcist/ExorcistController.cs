using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExorcistController : MonoBehaviour
{
    public AudioClip exorcistDamagedAudio;
    private AudioSource audioSource;
    public GameObject bulletPrefab;
    public float projectileSpawnDistance = 5;
    public float projectileVelocity = 10;
    public int maxHealth;
    public int currentHealth;
    private Vector3 playerPos;
    private Vector3 playerDirection;
    public int pillAmount = 0;
    public bool gotHearts = false;
    public bool gotCross = false;
    private bool nearHearths = false;
    private bool nearCross = false;
    private bool nearPortal = false;
    public string nextScene;
    public ExorcistItemController itemController;
    //public Sprite zombieSprite;
    private void Start()
    {
        if(gotCross)
        {
            itemController.CrossImage();
        }
        currentHealth = maxHealth;
    }
    void Update()
    {
        if (gotCross && Input.GetKeyDown(KeyCode.Space))
        {
            if (gameObject.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
            {
                return;
            }
            Fire();
        }
        if(nearCross && Input.GetKeyDown(KeyCode.E))
        {
            gotCross = true;
            itemController.CrossImage();
            itemController.CrossText(false);
        }
        if (nearHearths && Input.GetKeyDown(KeyCode.E))
        {
            gotHearts = true;
            itemController.HeartsText(false);
        }
        if (nearPortal && Input.GetKeyDown(KeyCode.E))
        {
            if(gotCross && gotHearts && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                SceneManager.LoadScene(nextScene);
            }
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
        if (collision.gameObject.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(exorcistDamagedAudio, transform.position);
            currentHealth--;
        }

        if (collision.gameObject.tag == "Item")
        {
            Destroy(collision.gameObject);
            pillAmount++;
            currentHealth++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gotHearts && collision.gameObject.name == "CupAsset")
        {
            nearHearths = true;
            itemController.HeartsText(true);

        }
        if (!gotCross && collision.gameObject.name == "CrossAsset")
        {
            nearCross = true;
            itemController.CrossText(true);
        }
        if(gotCross && gotHearts && collision.gameObject.name == "PortalSprite")
        {
            nearPortal = true;
            itemController.PortalReadyText(true);
        }
        else if(collision.gameObject.name == "PortalSprite")
        {
            itemController.PortalNotReadyText(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "CupAsset")
        {
            nearHearths = false;
            itemController.HeartsText(false);
        }
        if (collision.gameObject.name == "CrossAsset")
        {
            nearCross = false;
            itemController.CrossText(false);
        }
        if(collision.gameObject.name == "PortalSprite")
        {
            itemController.PortalReadyText(false);
            itemController.PortalNotReadyText(false);
        }
    }

}