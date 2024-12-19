using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;     // Reference to the Animator component
    private Rigidbody2D rb;        // Reference to Rigidbody2D for movement handling (if needed)
    private Vector2 movement;      // To store the player's movement input

    void Start()
    {
        // Get the Animator component attached to the player
        animator = GetComponent<Animator>();

        // Get the Rigidbody2D component (if needed for movement physics)
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Capture movement input (horizontal and vertical)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Call the method to handle animation transitions
        HandleAnimation();
    }

    void HandleAnimation()
    {
        // Check if the player is moving and determine the direction
        if (movement.x > 0)  // Moving Right
        {
            animator.SetBool("isMoving", true);
            animator.SetTrigger("MoveRight");
        }
        else if (movement.x < 0)  // Moving Left
        {
            animator.SetBool("isMoving", true);
            animator.SetTrigger("MoveLeft");
        }
        else if (movement.y > 0)  // Moving Up
        {
            animator.SetBool("isMoving", true);
            animator.SetTrigger("MoveUp");
        }
        else if (movement.y < 0)  // Moving Down
        {
            animator.SetBool("isMoving", true);
            animator.SetTrigger("MoveDown");
        }
        else  // Idle (no movement)
        {
            animator.SetBool("isMoving", false);
            animator.SetTrigger("Idle");
        }
    }
}
