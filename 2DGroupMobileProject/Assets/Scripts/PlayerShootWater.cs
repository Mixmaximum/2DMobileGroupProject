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
    float timer = 0;
    [SerializeField]
    float shootDelay = 0.5f;
    [SerializeField]
    float detectionRange = 10f;
    bool buttonPressed = false;
    public void Update()
    {
        timer += Time.deltaTime; //0.01666666666 if 60fps
        //if we press "the shoot button" (left mouse?)
        if ((Input.GetButton("Fire2") || buttonPressed) && timer > shootDelay && Time.timeScale != 0)
        {
            Shoot();
        }
    }
    public void ButtonDown()
    {
        buttonPressed = true;
    }
    public void ButtonUp()
    {
        buttonPressed = false;
    }
    public void Shoot()
    {
        Debug.Log("shoot");
        if (timer > shootDelay && Time.timeScale != 0)
        {
            timer = 0;
            // Find all objects tagged as "Enemy"
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            // determine the shoot direction
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
                    // Find the nearest enemy in range
                    if (distance < closestDistance)
                    {
                        nearestEnemy = enemy;
                        closestDistance = distance;
                    }
                }
            }
            // shoot towards nearby enemy
            if (nearestEnemy != null)
            {
                shootDirection = nearestEnemy.transform.position - transform.position;
                shootDirection.Normalize();
            }
            else
            {
                // If no enemies in range, shoot in default direction 
                shootDirection = transform.up;
            }
            // Spawn the bullet and set its velocity
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;
            Destroy(bullet, bulletLifetime);
        }

    }
}
