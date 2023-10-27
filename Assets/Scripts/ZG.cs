using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine.XR;
using UnityEngine.InputSystem;

public class ZG : MonoBehaviour
{
    [Header("Movement")]
    public float downAndUpSpeed;
    public float speed;
    public float maxSpeed = 1.0f; // Maximum speed in units per second.

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< Updated upstream
    public GameObject mainCamera;    // Reference to the main camera.
=======
    [Header("XR Tolkit Parts")]
    public ARSessionOrigin xrOrigin;
    public GameObject mainCamera; // Reference to the main camera.
>>>>>>> Stashed changes
=======
    [Header("XR Tolkit Parts")]
    public ARSessionOrigin xrOrigin;
    public GameObject mainCamera; // Reference to the main camera.
>>>>>>> parent of 65aed61 (ModifiedScripts)
=======
    [Header("XR Tolkit Parts")]
    public ARSessionOrigin xrOrigin;
    public GameObject mainCamera; // Reference to the main camera.
>>>>>>> parent of 65aed61 (ModifiedScripts)
=======
    [Header("XR Tolkit Parts")]
    public ARSessionOrigin xrOrigin;
    public GameObject mainCamera; // Reference to the main camera.
>>>>>>> parent of 65aed61 (ModifiedScripts)

    [Header("Hexabody Parts")]
    public GameObject Head;
    public GameObject Chest;
    public GameObject Fender;
    public GameObject Monoball;

    private Rigidbody rb;

    //public Scan scan;

    private Quaternion headYaw;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            scan.GetInfo();
            Debug.Log("Yes!");
        }

        float upDownInput = Input.GetAxis("UpDown");
        Vector3 upDownForce = Vector3.up * upDownInput * downAndUpSpeed;

        rb.AddForce(upDownForce * Time.deltaTime);

        // Check if a camera is assigned
        if (mainCamera != null)
        {
            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 cameraRight = mainCamera.transform.right;

            // Normalize the directions
            cameraForward.Normalize();
            cameraRight.Normalize();

            // Get Controllers Input
            headYaw = Quaternion.Euler(0, xrOrigin.cameraGameObject.transform.eulerAngles.y, 0); // set the head to the camera's rotation on the y axis

            // Calculate movement based on input axes
            Vector3 moveDirection = (cameraForward * Input.GetAxis("Vertical1") +
                                     cameraRight * Input.GetAxis("Horizontal1")).normalized;

        // Apply force in the calculated direction
        rb.AddForce(moveDirection * speed * Time.deltaTime);

            // Limit the maximum speed
            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }
        else
        {
            Debug.LogWarning("Main camera is not assigned!");
        }

        // Hexab0dy

        XRRigToPlayer();

    }

    private void FixedUpdate()
    {
        rotatePlayer();
    }

    private void XRRigToPlayer()
    {
        XRRig.transform.position = new Vector3(Fender.transform.position.x, Fender.transform.position.y - (0.5f * Fender.transform.localScale.y + 0.5f * Monoball.transform.localScale.y), Fender.transform.position.z);

    }

    private void rotatePlayer()
    {
        Chest.transform.rotation = headYaw;
    }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< Updated upstream
}
=======
}
*/

=======
}
*/
>>>>>>> parent of 65aed61 (ModifiedScripts)
=======
}
*/
>>>>>>> parent of 65aed61 (ModifiedScripts)
=======
}
*/
>>>>>>> parent of 65aed61 (ModifiedScripts)
