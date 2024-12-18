using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField]
    float knockbackForce = 10f;
    [SerializeField]
    float superKnockbackForce = 100f;
    private Rigidbody2D rb;
    private EnemyAI enemyAI;
    private int digit;
    [SerializeField]
    float knockbackChance = 30;
    [SerializeField]
    float superKnockbackChance = 1;
    float activeKnockback;
    public TrailRenderer trail;
    public Difficulty difficulty;
    float activeDifficulty;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        enemyAI = GetComponent<EnemyAI>();
        activeKnockback = knockbackForce;
        trail = GetComponentInChildren<TrailRenderer>();
        trail.emitting = false;
        difficulty = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Difficulty>();
        activeDifficulty = difficulty.activeDifficulty;
        knockbackChance = knockbackChance - activeDifficulty;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("WindBullet"))
        {
            digit = Random.Range(0, 101);
            if (digit <= knockbackChance && digit >= superKnockbackChance)
            {

                // Calculate the direction from the wind projectile to the current object
                Vector2 knockbackDirection = transform.position - collider.transform.position;

                // Apply knockback in the opposite direction
                ApplyKnockback(knockbackDirection);

                trail.emitting = true;

                Debug.Log("WEEEE");
            }
            if (digit <= superKnockbackChance)
            {
                // change knockback to a higher number
                activeKnockback = superKnockbackForce;

                // Calculate the direction from the wind projectile to the current object
                Vector2 knockbackDirection = transform.position - collider.transform.position;

                // Apply knockback in the opposite direction
                ApplyKnockback(knockbackDirection);

                trail.emitting = true;

                Debug.Log("SUPER WEEEE");
            }
        }
    }

    void ApplyKnockback(Vector2 direction)
    {
        // Prevent AI movement during knockback
        enemyAI.isKnockedBack = true;

        // Apply knockback
        rb.velocity = direction.normalized * activeKnockback;

        // reset knockback after a duration
        StartCoroutine(ResetKnockback());

        //reset knockback to normal
        activeKnockback = knockbackForce;
    }

    private IEnumerator ResetKnockback()
    {
        yield return new WaitForSeconds(0.5f);
        enemyAI.isKnockedBack = false;
        trail.emitting = false;
        rb.velocity = Vector2.zero; // stop movement after knockback
    }
}
