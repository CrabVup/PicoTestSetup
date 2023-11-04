using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public bool isPlaced;

    public void StartAction()
    {
        isPlaced = true;
        Debug.Log("isPlaced");

    }

    public void ExitAction()
    {
        isPlaced = false;
        gameObject.SetActive(false);
        Debug.Log("isOut");

    }

    private void OnTriggerEnter(Collider other)
    {
        isPlaced = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isPlaced = false;
    }
}
