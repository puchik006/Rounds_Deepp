using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Adjust the player's speed in the Unity Inspector.
    public float jumpForce = 5.0f; // Adjust the jump force in the Unity Inspector.
    private bool isGrounded = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from the player.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction.
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Move the player based on the input.
        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);

        // Flip the player when changing direction.
        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // Face right (0 degrees rotation).
        }
        else if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); // Face left (180 degrees rotation).
        }

        // Check for jump input.
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // Apply a vertical force to make the player jump.
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
