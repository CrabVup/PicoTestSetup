using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToObj : MonoBehaviour
{
    public Marker marker;
    // The speed the virus is moving towards the marker
    public float speed = 1.0f;

    // The target (marker) position
    public GameObject target;

    void Update()
    {
        if (marker.isPlaced)
        {
            // Move virus a step closer to the target
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }

    }
}
