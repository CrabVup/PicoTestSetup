using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public float speed = 1f; // Adjust the speed as needed
    public float cooldown = 1f; // Cooldown time in seconds
    public bool canShoot = true; // Flag to check if shooting is allowed
    private Rigidbody rb;
    public Tower tower; // Reference to the Tower script

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.velocity = transform.forward * speed; // Apply initial velocity to the bullet
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        //StartCoroutine(CooldownTimer());*/
    }

    /*public IEnumerator CooldownTimer()
    {
        canShoot = false; // Prevent shooting during cooldown
        yield return new WaitForSeconds(cooldown);
        canShoot = true; // Allow shooting again after cooldown
    }*/
}
