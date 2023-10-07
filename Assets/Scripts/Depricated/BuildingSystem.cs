using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    public GameObject gridUnit;
    public GameObject obj;
    public bool isDetected = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Grid"))
        {
            isDetected = true;
        }
    }
    public void Placement()
    {
        if (isDetected == true)
        {
            Vector3 pos = gridUnit.transform.position;
            obj.transform.position = pos;
        }
    }
}
