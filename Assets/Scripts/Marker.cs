using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public bool isPlaced;

    void Start()
    {

    }

    void Update()
    {
     
   
    }
    public void StartAction()
    {
        isPlaced = true;
        Debug.Log("isPlaced");

    }

    public void ExitAction()
    {
        isPlaced = false;
        Debug.Log("isOut");

    }
}
