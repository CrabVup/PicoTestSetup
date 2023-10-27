using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullAway : MonoBehaviour
{
    public float pushForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // collision.getcontact()

        // Check if the collision is with the player character
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Touch me!");
            // Calculate the direction from the object to the player
            Vector3 pushDirection = collision.transform.position - transform.position;
            Vector3 playerForward = collision.transform.forward;
            Vector3 bounceDirection = Vector3.Reflect(playerForward, pushDirection);

            //Debug.DrawRay(transform.position, pushDirection * 10, Color.red);

            // Normalize the direction to get a unit vector
            pushDirection.Normalize();

            // Apply a force to move the object away from the player
            GetComponent<Rigidbody>().AddForce(bounceDirection * pushForce, ForceMode.Impulse);
        }
    }
}
