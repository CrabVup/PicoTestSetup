using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateDistance : MonoBehaviour
{
    // Movement
    private Rigidbody rb;
    private float dirX, dirZ, moveSpeed = 5f;

    // Reference to Virus Position
    [SerializeField]
    private Transform virus;

    // Reference to the UI Text that shows the distance value
    [SerializeField]
    private Text distanceText;

    // The Distance Value that's calculated
    private float distance;

    void Start()
    {
        // Movement
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        dirZ = Input.GetAxisRaw("Vertical") * moveSpeed;

        // Calculate distance value between player & virus
        distance = (virus.transform.position - transform.position).magnitude;

        // Display distance value via UI text
        // distanceToString(F1) shows value with 1 digit after period (ex. 12.3)
        // distanceToString(F2) will show 2 digits after period (ex. 12.31)
        distanceText.text = "Distance: " + distance.ToString("F1") + "metres";
    }

    private void FixedUpdate()
    {
        // Movement
        rb.velocity = new Vector3(dirX, rb.velocity.y, dirZ);
    }
}
