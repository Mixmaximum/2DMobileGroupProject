using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootWater : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    float bulletSpeed = 10f;
    [SerializeField]
    float bulletLifetime = 2.0f;
    [SerializeField]
    float detectionRange = 10f;

    public void Shoot()
    {
        // Find all objects tagged as "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // Determine the shoot direction
        Vector3 shootDirection = Vector3.zero;
        GameObject nearestEnemy = null;
        float closestDistance = Mathf.Infinity;

        // Check each enemy in range
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            // Only shoot enemies in range
            if (distance <= detectionRange)
            {
                if (distance < closestDistance)
                {
                    nearestEnemy = enemy;
                    closestDistance = distance;
                }
            }
        }

        // Shoot towards the nearest enemy
        if (nearestEnemy != null)
        {
            shootDirection = nearestEnemy.transform.position - transform.position;
            shootDirection.Normalize();
        }
        else
        {
            shootDirection = transform.up; // Default shoot direction
        }

        // Spawn the bullet and set its velocity
        GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;
        Destroy(bullet, bulletLifetime);
    }
}
