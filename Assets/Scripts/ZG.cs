using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZG : MonoBehaviour
{
    public float speed;
    public GameObject mainCamera;
    private Rigidbody rb;
    private float maxSpeed = 10f; // Maximum allowed speed

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if a camera is assigned
        if (mainCamera != null)
        {
            // Get the camera's forward direction
            Vector3 cameraForward = mainCamera.transform.forward;

            // Normalize the forward direction
            cameraForward.Normalize();

            // Apply force in the camera's forward direction
            rb.AddForce(cameraForward * speed * Input.GetAxis("Vertical") * Time.deltaTime);

            // Calculate the real speed
            float realSpeed = rb.velocity.magnitude;

            // Limit the real speed to a maximum value of 10
            if (realSpeed > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }

            // Display the real speed
            Debug.Log("Real Speed: " + realSpeed);
        }
        else
        {
            Debug.LogWarning("Main camera is not assigned!");
        }
    }
}
