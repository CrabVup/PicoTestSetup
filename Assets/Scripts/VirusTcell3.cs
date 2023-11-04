using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusTcell3 : MonoBehaviour
{
  public CalculateDistance calculateDistance;
    public PlayerHealth playerHealth;
    //public MarkerC marker;
    // The speed the T-Cells are moving towards the marker
    public float speed = 1.0f;
    public List<GameObject> gameObjectsWithMarkerC = new List<GameObject>();

    void Start()
    {
        // Find all GameObjects with the Marker script and add them to the list.
        
    }

    public void FindGameObjectsWithMarkerC()
    {
        // Find all GameObjects in the scene with the Marker script.
        MarkerC[] markers = FindObjectsOfType<MarkerC>();

        // Add the GameObjects with the Marker script to the list.
        foreach (MarkerC marker in markers)
        {
            gameObjectsWithMarkerC.Add(marker.gameObject);
        }
    }
    void Update()
    {
        foreach (GameObject gameObjectWithMarkerC in gameObjectsWithMarkerC)
        {
            // Get the Marker script from the GameObject.
            Marker marker = gameObjectWithMarkerC.GetComponent<Marker>();

            // Check if the marker's isPlaced property is true.
            if (marker != null && marker.isPlaced)
            {
                // Move T-Cell towards the virus.
                var step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, marker.transform.position, step);
            }
        }
       /* if (marker.isPlaced)
        {
            // Move T-Cell a step closer to the virus
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, marker.transform.position, step);
        }*/
    }

    public void OnTriggerEnter(Collider other)
    {
        FindGameObjectsWithMarkerC();
        foreach (GameObject gameObjectWithMarkerC in gameObjectsWithMarkerC)
        {
            // Get the Marker script from the GameObject.
            Marker marker = gameObjectWithMarkerC.GetComponent<Marker>();

            // Check if the marker's isPlaced property is true.
            if (marker != null && marker.isPlaced)
            {
                if (other.CompareTag("bacteria"))
                {
                    GetComponent<AudioSource>().Play();
                    playerHealth.Increase();
                    Destroy(other.gameObject);
                    marker.gameObject.SetActive(false);
                    calculateDistance.virusADestroyed = true; // this is only for virus a, you'll need to add those tags for the other two viruses
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
        /*if (other.CompareTag("bacteria"))
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
        marker.isPlaced = false;*/
    }
}
