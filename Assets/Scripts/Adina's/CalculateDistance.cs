using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalculateDistance : MonoBehaviour
{
    public bool virusADestroyed;
    public bool virusBDestroyed;
    public bool bacteriaDestroyed;
    // Movement
    //private Rigidbody rb;
    //private float dirX, dirZ, moveSpeed = 5f;

    // Reference to Virus Position
    [SerializeField]
    private Transform virusA;
    [SerializeField]
    private Transform virusB;
    [SerializeField]
    private Transform bacteria;

    // Reference to the UI Text that shows the distance value
    [SerializeField]
    private TextMeshProUGUI distanceTextVirusA;
    [SerializeField]
    private TextMeshProUGUI distanceTextVirusB;
    [SerializeField]
    private TextMeshProUGUI distanceTextBacteria;

    // The Distance Value that's calculated
    private float distance;

    void Start()
    {
        // Movement
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (virusADestroyed == false)
        {
            if (virusA != null)
            {
                // Calculate distance value between player & virus
                distance = (virusA.transform.position - transform.position).magnitude;

                // Display distance value via UI text
                // distanceToString(F1) shows value with 1 digit after period (ex. 12.3)
                // distanceToString(F2) will show 2 digits after period (ex. 12.31)
                distanceTextVirusA.text = "Distance Virus A: " + distance.ToString("F1") + "metres";
            } else
            {
                distanceTextVirusA.text = "Cleaned!";
            }
        } else
        {
            distanceTextVirusA.text = "Cleaned!";
        }

        if (virusBDestroyed == false)
        {
            if (virusB != null)
            {
                distance = (virusB.transform.position - transform.position).magnitude;
                distanceTextVirusB.text = "Distance Virus B: " + distance.ToString("F1") + "metres";
            } else
            {
                distanceTextVirusB.text = "Cleaned!";
            }
        }
        else
        {
            distanceTextVirusB.text = "Cleaned!";
        }

        if (bacteriaDestroyed == false)
        {
            if (bacteria != null)
            {
                distance = (bacteria.transform.position - transform.position).magnitude;
                distanceTextBacteria.text = "Distance Bacteria: " + distance.ToString("F1") + "metres";
            } else
            {
                distanceTextBacteria.text = "Cleaned!";
            }
        }
        else
        {
            distanceTextBacteria.text = "Cleaned!";
        }
    }

    private void FixedUpdate()
    {
        // Movement
        //rb.velocity = new Vector3(dirX, rb.velocity.y, dirZ);
    }
}