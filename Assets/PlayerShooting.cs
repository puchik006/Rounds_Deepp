using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign your bullet prefab in the Unity Inspector.
    public Transform firePoint; // Point from which bullets will be spawned.
    public float bulletSpeed = 10f; // Speed of the bullets.
    public float fireRate = 0.5f; // Fire rate in seconds.
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
        // Instantiate a bullet at the fire point's position and rotation.
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the bullet's Rigidbody2D component.
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Set the bullet's velocity to make it move in the forward direction.
        rb.velocity = transform.right * bulletSpeed;
    }
}
