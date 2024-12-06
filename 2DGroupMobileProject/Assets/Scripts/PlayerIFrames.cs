using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIFrames : MonoBehaviour
{
    public float invincibilityDuration = 2f;
    private bool isInvincible = false;
    private float invincibilityTimeRemaining = 0f; 
    public float cooldown = 1f;
    private float cooldownCounter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        isInvincible = false;
        cooldownCounter = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isInvincible)
        {
            invincibilityTimeRemaining -= Time.deltaTime;

            if (invincibilityTimeRemaining <= 0)
            {
                isInvincible = false;
                Debug.Log("No longer invincible");
                cooldownCounter = cooldown;
            }
        }

        if (cooldownCounter > 0)
        {
            cooldownCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Invincibility();
        }
    }

    private void Invincibility()
    {
        if (!isInvincible && cooldownCounter <= 0)
        {
            isInvincible = true;
            invincibilityTimeRemaining = invincibilityDuration;
            Debug.Log("Can't touch this");
        }
    }
}
