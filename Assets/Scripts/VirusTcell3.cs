using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX.Utility;
using UnityEngine.VFX;

public class VirusTcell3 : MonoBehaviour
{
  public CalculateDistance calculateDistance;
    public PlayerHealth playerHealth;
    public GameObject virusDeathVfx;
    public VisualEffect lineVfx;
    public static bool isPath;
    public VFXTransformBinderExternal vfxPositionBinder;
    //public MarkerC marker;
    // The speed the T-Cells are moving towards the marker
    public float speed = 1.0f;
    public List<GameObject> gameObjectsWithMarkerC = new List<GameObject>();

    public bool isKilled;

    public virusAudio killVoice;

    void Start()
    {
        // Find all GameObjects with the Marker script and add them to the list.
        isKilled = false;
        isPath = false;
        //vfxPositionBinder.GetComponent<VFXPositionBinder>();
    }

    public void FindGameObjectsWithMarkerC()
    {
        MarkerC[] markers = FindObjectsOfType<MarkerC>();

        // Clear the existing list as we are going to update it.
        gameObjectsWithMarkerC.Clear();

        // Create a set to keep track of markers you've already processed.
        HashSet<MarkerC> processedMarkers = new HashSet<MarkerC>();

        foreach (MarkerC marker in markers)
        {
            // Check if we've already processed this marker.
            if (!processedMarkers.Contains(marker))
            {
                gameObjectsWithMarkerC.Add(marker.gameObject);

                // Add the marker to the set of processed markers.
                processedMarkers.Add(marker);
            }
            vfxPositionBinder.Target = marker.transform;
        }
    }
    void Update()
    {
        if (isPath)
        {
            lineVfx.enabled = true;
        }
        else
        {
            lineVfx.enabled = false;
        }

        foreach (GameObject gameObjectWithMarkerC in gameObjectsWithMarkerC)
        {
            // Get the Marker script from the GameObject.
            MarkerC marker = gameObjectWithMarkerC.GetComponent<MarkerC>();

            // Check if the marker's isPlaced property is true.
            if (marker != null && marker.isPlaced)
            {
                isPath = true;
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
     
        foreach (GameObject gameObjectWithMarkerC in gameObjectsWithMarkerC)
        {
            // Get the Marker script from the GameObject.
            MarkerC marker = gameObjectWithMarkerC.GetComponent<MarkerC>();

            // Check if the marker's isPlaced property is true.
            if (marker != null && marker.isPlaced)
            {
                if (other.CompareTag("bacteria"))
                {
                    GetComponent<AudioSource>().Play();
                    killVoice.KillingVirus();
                    playerHealth.Increase();
                    other.gameObject.SetActive(false);
                    Instantiate(virusDeathVfx, other.transform.position, Quaternion.identity);
                    isKilled = true;
                    marker.gameObject.SetActive(false);
                    calculateDistance.virusADestroyed = true; // this is only for virus a, you'll need to add those tags for the other two viruses
                }
                else
                {
                    GetComponent<AudioSource>().Play();
                    killVoice.TCellDied();
                    playerHealth.Decrease();
                    Instantiate(virusDeathVfx, other.transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                    marker.gameObject.SetActive(false);
                }
                marker.isPlaced = false;
                isPath = false;
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
