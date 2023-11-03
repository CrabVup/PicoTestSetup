using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestCell : MonoBehaviour
{
    public Transform[] TCells;

    float distanceFromTarget;

    // The speed the t-cell is moving towards the marker
    public float speed = 1.0f;

    //public Marker marker;

    // Update is called once per frame
    void Update()
    {
        int mainTarget = 0;

        float shortestDistance = Vector3.Distance(TCells[0].position, transform.position);

        Debug.Log(shortestDistance);

        for (int i = 1; i < TCells.Length; i++)
        {
            Debug.Log(TCells[i]);

            if (TCells[i] != null)
            {
                distanceFromTarget = Vector3.Distance(TCells[i].position, transform.position);

                Debug.Log(distanceFromTarget);

                if (distanceFromTarget < shortestDistance)
                {
                    shortestDistance = distanceFromTarget;
                    mainTarget = i;
                }
            }

            Debug.Log(shortestDistance);
        }

        // if (marker.isPlaced)
        //{
        // Move cell a step closer to the marker
        var step = speed * Time.deltaTime; // calculate distance to move
            TCells[mainTarget].transform.position = Vector3.MoveTowards(TCells[mainTarget].transform.position, transform.position, step);
        //}
    }
}
