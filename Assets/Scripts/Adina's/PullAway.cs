using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullAway : MonoBehaviour
{
    public float pushForce = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        // collision.getcontact()

        // Check if the collision is with the player character
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Touch me!");
            // Calculate the direction from the object to the player
            Vector3 pushDirection = collision.transform.position - transform.position;
            //Vector3 playerForward = collision.transform.forward;
            //Vector3 bounceDirection = Vector3.Reflect(playerForward, pushDirection);

            //Debug.DrawRay(transform.position, pushDirection * 10, Color.red);

            // Normalize the direction to get a unit vector
            pushDirection.Normalize();

            // Calculate the bounce direction using the wall's normal
            Vector3 wallNormal = collision.contacts[0].normal;
            Vector3 bounceDirection = Vector3.Reflect(pushDirection, wallNormal);

            // Apply a force to move the object away from the player
            GetComponent<Rigidbody>().AddForce(bounceDirection * pushForce, ForceMode.Impulse);
        }
    }
}
