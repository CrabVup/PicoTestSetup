using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCell : MonoBehaviour
{   
    public float speed = 3;
    public Vector3 target = new Vector3(0, 0, 1);
    private void Update()
    {
        // movement of the cell from point A to B
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        // rotation of the cell 
        transform.Rotate(0.05f, 5f * Time.deltaTime, 0.05f, Space.Self);
    }
}
