using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Resource : MonoBehaviour
{
    public List<GameObject> resources;
    public GameObject target;
    public bool isMatched1;
    public bool isMatched2;
    public Transform SpawnPoint;

    void Start()
    {
        
    }
    void Update()
    {
        if(isMatched1 && isMatched2)
        {
            Debug.Log("Call");
            Invoke("Generate", 0f);
        }
    }
    public void ResourceAction1()
    {
        isMatched1 = true;
        Debug.Log("M1");

    }

    public void ResourceAction2()
    {
        isMatched2 = true;
        Debug.Log("M2");

    }
    public void Generate()
    {
        Debug.Log("Created");
        GameObject newTarget = Instantiate(target, SpawnPoint.position, SpawnPoint.rotation);
    }
}
