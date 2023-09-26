using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyDelay = 0.5f; // Adjust the delay before the bullet is destroyed.

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the bullet collides with something other than the player.
        if (!collision.gameObject.CompareTag("Player"))
        {
            // Disable the bullet's renderer and collider.
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            // Destroy the bullet after a delay.
            Destroy(gameObject, destroyDelay);
        }
    }
}