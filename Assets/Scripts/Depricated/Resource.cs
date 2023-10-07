using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Resource : MonoBehaviour
{
    public List<GameObject> resources;
    
    public bool isMatched1;
    public bool isMatched2;
  

    void Start()
    {
        
    }
    void Update()
    {
       
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
   
}
