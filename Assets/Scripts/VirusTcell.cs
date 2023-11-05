using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusTcell : MonoBehaviour
{
    public CalculateDistance calculateDistance;
    public PlayerHealth playerHealth;
   // public Marker marker;
    // The speed the T-Cells are moving towards the marker
    public float speed = 1.0f;
    public List<GameObject> gameObjectsWithMarker = new List<GameObject>();
    public CraftingSystem craft;
    void Start()
    {
        // Find all GameObjects with the Marker script and add them to the list.
   
    }

    public void FindGameObjectsWithMarker()
    {
        // Find all GameObjects in the scene with the Marker script.
        Marker[] markers = FindObjectsOfType<Marker>();

        // Add the GameObjects with the Marker script to the list.
        foreach (Marker marker in markers)
        {
            gameObjectsWithMarker.Add(marker.gameObject);
        }
    }
    void Update()
    {
        if (craft.isCreated)
        {
            FindGameObjectsWithMarker();
        }
        foreach (GameObject gameObjectWithMarker in gameObjectsWithMarker)
        {
            // Get the MarkerB script from the GameObject.
            Marker marker = gameObjectWithMarker.GetComponent<Marker>();

            // Check if the marker's isPlaced property is true.
            if (marker != null && marker.isPlaced)
            {
                // Move T-Cell towards the virus.
                var step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, marker.transform.position, step);
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
     
        foreach (GameObject gameObjectWithMarker in gameObjectsWithMarker)
        {
            // Get the MarkerB script from the GameObject.
            Marker marker = gameObjectWithMarker.GetComponent<Marker>();

            // Check if the marker's isPlaced property is true.
            if (marker != null && marker.isPlaced)
            {
                if (other.CompareTag("VirusA"))
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
    }
}
