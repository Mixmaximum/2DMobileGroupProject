using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIFrames : MonoBehaviour
{
    public float invincibilityDuration = 2f; 
    private bool isInvincible = false;
    private float invincibilityTimer = 0f;
    public float cooldown = 1f;
    float cooldownCounter;
    // Start is called before the first frame update
    void Start()
    {
        isInvincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible == true)
        {
            invincibilityTimer -= Time.deltaTime;

            if (invincibilityTimer <= 0)
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
        if (!isInvincible && cooldown <= 0)
        {
            isInvincible = true;
            invincibilityTimer = invincibilityDuration;
            Debug.Log("Can't touch this");
        }

    }
    
}
