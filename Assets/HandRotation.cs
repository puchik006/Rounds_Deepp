using UnityEngine;

public class HandRotation : MonoBehaviour
{
    public Transform body; // Reference to the body GameObject.
    public float rotationSpeed = 5f; // Adjust the rotation speed in the Inspector.

    private void Update()
    {
        // Get the mouse position in world space.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Make sure the z-coordinate is 0.

        // Calculate the direction from the body to the mouse position.
        Vector3 direction = mousePosition - body.position;

        // Calculate the angle in radians and convert it to degrees.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the hand towards the mouse position.
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
