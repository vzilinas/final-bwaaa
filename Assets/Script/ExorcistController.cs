﻿using UnityEngine;

public class ExorcistController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float projectileSpawnDistance = 5;
    public float projectileVelocity = 10;
    private Vector3 playerPos;
    private Vector3 playerDirection;

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
}