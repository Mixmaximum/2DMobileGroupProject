using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    InputActionReference moveActionReference;
    float activeMoveSpeed;
    public float dashSpeed = 10f;
    public float dashLength = 0.5f;
    public float dashCooldown = 1f;
    float dashCounter;
    float dashCoolCounter;
    public TrailRenderer trail;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = moveSpeed; // Initially set to moveSpeed
        rb = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
        trail.emitting = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDir = moveActionReference.action.ReadValue<Vector2>();
        rb.velocity = moveDir * activeMoveSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            Dash();
        }

        //dash duration
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime; // Link dash to timer
            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed; // Reset to normal speed after dash ends
                dashCoolCounter = dashCooldown; // Start cooldown
            }
        }

        //dash cooldown
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime; // Decrease cooldown
        }

        if (dashCounter <= 0)
        { 
            trail.emitting = false;
        }
    }
        //dash input
       public void Dash()
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0) 
            {
                activeMoveSpeed = dashSpeed; // change player speed
                dashCounter = dashLength; // Start dash
                trail.emitting = true;
            }
          
       }
}
