using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSpawn : MonoBehaviour
{
    public Resource resource;
    public GameObject target;
    public Transform SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        resource = GetComponent<Resource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(resource.isMatched1 && resource.isMatched2)
        {
            Debug.Log("Call");
            Invoke("Generate", 0f);
        }
    }
    public void Generate()
    {
        Debug.Log("Created");
        GameObject newTarget = Instantiate(target, SpawnPoint.position, SpawnPoint.rotation);
    }
}
