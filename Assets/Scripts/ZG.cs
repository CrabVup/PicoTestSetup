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
    public float maxSpeed = 5f; // Maximum speed in units per second.

    public GameObject mainCamera;    // Reference to the main camera.

     private Rigidbody rb;

    public Scan scan;

    public GameObject scanVFX;
    public GameObject scanVFX2;
    public ContinuousMoveProviderBase movementScript;
    public BoxCollider stationCollider;

    public AudioSource scanSounds;
    public AudioClip scanPressed, scanReleased;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scanVFX.SetActive(false);
        scanVFX2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            scanSounds.clip = scanPressed;
            scanSounds.Play();
            scan.GetInfo();
            Debug.Log("Yes!");
            
            if (scan.isScanned)
            {
                scanVFX.SetActive(true);
            }else
            {
                scanVFX2.SetActive(true);
            }

        }else
        {
            scanVFX.SetActive(false);
            scanVFX2.SetActive(false);

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

            // Calculate movement based on input axes
            Vector3 moveDirection = (cameraForward * Input.GetAxis("Vertical1") +
                                     cameraRight * Input.GetAxis("Horizontal1")).normalized;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == stationCollider.GetComponent<Collider>())
        {
            rb.useGravity = true;
            movementScript.enabled = true; // Disable the script.
            maxSpeed = 100;
            speed = 0;
            downAndUpSpeed = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == stationCollider.GetComponent<Collider>())
        {
            rb.useGravity = false;
            movementScript.enabled = false; 
            maxSpeed = 5;
            speed = 20;
            downAndUpSpeed = 25;
            //rb.velocity = new Vector3(0, 0, 0);
        }
    }


}


