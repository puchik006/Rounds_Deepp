using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign your bullet prefab in the Unity Inspector.
    public Transform firePoint; // Point from which bullets will be spawned.
    public float bulletSpeed = 10f; // Speed of the bullets.
    public float fireRate = 0.5f; // Fire rate in seconds.
    public float bulletForce = 20f; // Initial force applied to bullets.
    private float nextFireTime = 0f; // Time at which the next shot can be fired.

    void Update()
    {
        // Check if it's time to fire again.
        if (Time.time >= nextFireTime)
        {
            // Check for fire input (e.g., left mouse button or any key).
            if (Input.GetButtonDown("Fire1")) // Change "Fire1" to your desired input.
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate; // Calculate the next allowed fire time.
            }
        }
    }

    void Shoot()
    {
        // Calculate the direction from the fire point to the mouse position.
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)firePoint.position).normalized;

        // Instantiate a bullet at the fire point's position and rotation.
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Get the bullet's Rigidbody2D component.
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Apply an initial force to the bullet in the calculated direction.
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);

        // Set the bullet's velocity to make it move at a constant speed.
        rb.velocity = direction * bulletSpeed;
    }
}
