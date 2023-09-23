using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f; // Adjust the speed as needed

    private Rigidbody rb;
    public Tower tower; // Reference to the Tower script

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.velocity = transform.forward * speed; // Apply initial velocity to the bullet
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
