using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusTcell3 : MonoBehaviour
{
  public CalculateDistance calculateDistance;
    public PlayerHealth playerHealth;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VirusB"))
        {
            GetComponent<AudioSource>().Play();
            playerHealth.Increase();
            Destroy(other.gameObject);
            calculateDistance.virusADestroyed = true; // this is only for virus a, u'll need to add those tags for the other two viruses
        }
        else
        {
            GetComponent<AudioSource>().Play();
            playerHealth.Decrease();
            Destroy(this.gameObject);
        }
    }
}
