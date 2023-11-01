using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestCell : MonoBehaviour
{
    public Transform[] TCells;

    float DistanceFromTarget;
    float DistanceFromLastTarget;
    int MainTarget;

    // The speed the virus is moving towards the marker
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < TCells.Length; i++)
        //TCells.size returns the size of the array//
        {
            if (TCells[i] != null)
            {
                DistanceFromTarget = Vector3.Distance(TCells[i].position, transform.position);

                if (i > 0)
                {
                    DistanceFromLastTarget = Vector3.Distance(TCells[i - 1].position, transform.position);
                }
                else
                {
                    DistanceFromLastTarget = 0f;
                }

                if (DistanceFromTarget < DistanceFromLastTarget)
                {
                    MainTarget = i;
                }
            }
        }

        // Move cell a step closer to the marker
        var step = speed * Time.deltaTime; // calculate distance to move
        TCells[MainTarget].transform.position = Vector3.MoveTowards(TCells[MainTarget].transform.position, transform.position, step);
    }
}
