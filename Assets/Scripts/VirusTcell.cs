using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusTcell : MonoBehaviour
{
    public CalculateDistance calculateDistance;
    public PlayerHealth playerHealth;
    public Marker marker;
    // The speed the T-Cells are moving towards the marker
    public float speed = 1.0f;

    void Update()
    {
        if (marker.isPlaced)
        {
            // Move T-Cell a step closer to the virus
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, marker.transform.position, step);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VirusA"))
        {
            GetComponent<AudioSource>().Play();
            playerHealth.Increase();
            Destroy(other.gameObject);
            marker.gameObject.SetActive(false);
            calculateDistance.virusADestroyed = true; // this is only for virus a, u'll need to add those tags for the other two viruses
        }
        else
        {
            GetComponent<AudioSource>().Play();
            playerHealth.Decrease();
            Destroy(this.gameObject);
            marker.gameObject.SetActive(false);
        }
        marker.isPlaced = false;
    }
}
