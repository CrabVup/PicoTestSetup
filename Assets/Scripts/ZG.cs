using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZG : MonoBehaviour
{
    //public float rotateSpeed;
    //public float turnSpeed;
    //public float downAndUpSpeed;
    public float speed;
    public GameObject mainCamera; // Reference to the main camera.

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (speed > 10)
        {
            speed = 10;
        }

       //transform.Rotate(new Vector3(0, 0, -1) * rotateSpeed * Input.GetAxis("Roll") * Time.deltaTime);
        //transform.Rotate(new Vector3(1, 0, 0) * downAndUpSpeed * Input.GetAxis("UpDown") * Time.deltaTime);
        //transform.Rotate(new Vector3(0, 1, 0) * turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);

        // Check if a camera is assigned
        if (mainCamera != null)
        {
            // Get the camera's forward direction
            Vector3 cameraForward = mainCamera.transform.forward;

            // Normalize the forward direction
            cameraForward.Normalize();

            // Apply force in the camera's forward direction
            rb.AddForce(cameraForward * speed * Input.GetAxis("Vertical") * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Main camera is not assigned!");
        }
    }
}
