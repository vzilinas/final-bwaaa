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
    private Vector3 lastPlayerDirection;
    private Vector3 projectileSpawnPos;
    private float gunCooldown;
    private bool canShoot;
    public int pillAmount = 0;
    public bool gotHearts = false;
    public bool gotCross = false;
    private bool nearHearths = false;
    private bool nearCross = false;
    public bool nearNextPortal = false;
    public bool nearPreviousPortal = false;
    public int highScore;

    public HelperTextController textController;
    private void Start()
    {
        currentHealth = maxHealth;
        textController = GameObject.Find("HelperText").GetComponent<HelperTextController>();
    }
    void Update()
    {
        if(textController == null)
        {
            textController = GameObject.Find("HelperText").GetComponent<HelperTextController>();
        }
        if (gameObject.GetComponent<Rigidbody2D>().velocity.normalized != Vector2.zero)
        {
            lastPlayerDirection = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
        }

        if (gotCross && Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Fire();
            gunCooldown = Time.time + 0.3f;
            canShoot = false;
        }
        if (!canShoot && Time.time > gunCooldown)
        {
            canShoot = true;

        }
        if (nearCross && Input.GetKeyDown(KeyCode.E))
        {
            gotCross = true;
            textController.CrossImage();
            textController.CrossText(false);
            HighScore.score += 10;
            highScore = HighScore.score;
        }
        if (nearHearths && Input.GetKeyDown(KeyCode.E))
        {
            gotHearts = true;
            currentHealth = maxHealth;
            textController.HeartsText(false);
            HighScore.score += 10;
            highScore = HighScore.score;
        }
        if (nearNextPortal && Input.GetKeyDown(KeyCode.E))
        {
            if(gotCross && gotHearts && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                GameObject.Find("SceneChanger").GetComponent<LevelChanger>().next = true;
                gameObject.transform.position = new Vector2(-40, -130);
                nearNextPortal = false;
            }
        }
        if (nearPreviousPortal && Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Find("SceneChanger").GetComponent<LevelChanger>().previous = true;
            gameObject.transform.position = new Vector2(-40, -130);
            nearPreviousPortal = false;    
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
        if (playerDirection == Vector3.zero)
        {
            projectileSpawnPos = playerPos + lastPlayerDirection * projectileSpawnDistance;
        }
        else
        {
            projectileSpawnPos = playerPos + playerDirection * projectileSpawnDistance;
        }

        var bullet = Instantiate(
            bulletPrefab,
            projectileSpawnPos,
            Quaternion.Euler(new Vector3(0, 0, 1)));

        if (playerDirection == Vector3.zero)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = lastPlayerDirection * projectileVelocity;
        }
        else
        {
            bullet.GetComponent<Rigidbody2D>().velocity = playerDirection * projectileVelocity;
        }

        Destroy(bullet, 1.0f);
    }

    private void Die()
    {
        //Destroy(gameObject);
        SceneManager.LoadScene("Score");
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
            HighScore.score += 50;
            Destroy(collision.gameObject);
            pillAmount++;
            currentHealth++;
        }

        if(collision.gameObject.tag == "ShovelProjectile")
        {
            Destroy(collision.gameObject);
            currentHealth--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gotHearts && collision.gameObject.name == "CupAsset")
        {
            nearHearths = true;
            textController.HeartsText(true);
        }
        if(currentHealth < maxHealth && collision.gameObject.name == "CupAsset")
        {
            nearHearths = true;
            textController.HeartsText(true);
        }
        if (!gotCross && collision.gameObject.name == "CrossAsset")
        {
            nearCross = true;
            textController.CrossText(true);
        }
        if (gotCross && gotHearts && collision.gameObject.name == "NextPortal" && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            nearNextPortal = true;
            textController.PortalReadyText(true);
        }
        else if (collision.gameObject.name == "PreviousPortal")
        {
            nearPreviousPortal = true;
            textController.PortalBackText(true);
        }
        else if (collision.gameObject.name.Contains("Portal") )
        {
            textController.PortalNotReadyText(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "CupAsset")
        {
            nearHearths = false;
            textController.HeartsText(false);
        }
        if (collision.gameObject.name == "CrossAsset")
        {
            nearCross = false;
            textController.CrossText(false);
        }
        if (collision.gameObject.name.Contains("Portal"))
        {
            nearNextPortal = false;
            nearPreviousPortal = false;
            textController.PortalReadyText(false);
            textController.PortalBackText(false);
            textController.PortalNotReadyText(false);
        }
    }

}