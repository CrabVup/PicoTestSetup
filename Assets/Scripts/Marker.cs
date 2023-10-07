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
    public void StartTowerAction()
    {
        isPlaced = true;
        Debug.Log("isPlaced");

    }

    public void ExitTowerAction()
    {
        isPlaced = false;
        Debug.Log("isOut");

    }
}
