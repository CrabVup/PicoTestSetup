using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ZeroGravityController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control your movement speed.

    private Rigidbody rb;
    private InputAction moveAction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = new InputAction("Move", InputActionType.PassThrough, "<XRController>/{LeftHandDevice}/primary2DAxis");
        moveAction.Enable();
    }

    private void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(input.x, 0, input.y) * moveSpeed;

        // Apply the movement force to the Rigidbody.
        rb.AddForce(movement);
    }
}
