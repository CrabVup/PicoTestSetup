using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToObj : MonoBehaviour
{
    public Marker marker;
    // The speed the T-Cells are moving towards the marker
    public float speed = 1.0f;

    // The target (virus) position
    public GameObject target;

    void Update()
    {
        if (marker.isPlaced)
        {
            // Move T-Cell a step closer to the virus
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, target.transform.position);
    }
}
