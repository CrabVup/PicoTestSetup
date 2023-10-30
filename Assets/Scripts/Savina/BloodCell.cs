using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCell : MonoBehaviour
{
    public float minSpeed = 2f;
    public float maxSpeed = 5f;
    public float maxRotationSpeed = 100f;

    private Vector3 initialRotation;
    private Vector3 rotationAxis;
    private float rotationSpeed;
    private float speed;

    private void Start()
    {
        // Randomly set the initial rotation
        initialRotation = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
        transform.eulerAngles = initialRotation;

        // Randomly set the rotation axis
        rotationAxis = Random.onUnitSphere;

        // Randomly set the initial rotation speed
        rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);

        // Randomly set the cell speed
        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        // Move the cell forward along the global forward direction
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);

        // Rotate the cell around the chosen rotation axis at a variable speed
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
