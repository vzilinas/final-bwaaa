using UnityEngine;

public class ShootingTowardsPlayer : MonoBehaviour
{
    //[SerializeField]
    public GameObject projectile;
    public float fireRate;
    private float nextFire;
    private Vector3 shooterPos;
    private Vector3 shooterDirection;
    private Vector3 shooterLastDirection;
    private Vector3 projectileSpawnPos;
    public float projectileSpawnDistance = 5;

    void Start()
    {
        nextFire = Time.time;
    }

    void Update()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity.normalized != Vector2.zero)
        {
            shooterLastDirection = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
        }

        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            shooterPos = gameObject.transform.position;
            shooterDirection = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
            if (shooterDirection == Vector3.zero)
            {
                projectileSpawnPos = shooterPos + shooterLastDirection * projectileSpawnDistance;
            }
            else
            {
                projectileSpawnPos = shooterPos + shooterDirection * projectileSpawnDistance;
            }

            Instantiate(projectile, projectileSpawnPos, Quaternion.Euler(new Vector3(0, 0, 1)));

            nextFire = Time.time + fireRate;
        }

    }

}
