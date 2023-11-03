using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCellsComing : MonoBehaviour
{
    public Virus virus;
    public Marker marker;

    // The speed the T-Cells are moving towards the marker
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (marker.isPlaced)
        {

        }
    }
}
