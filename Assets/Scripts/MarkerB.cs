using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerB : MonoBehaviour
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
        //gameObject.SetActive(false);
        Debug.Log("isOut");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Scannable"))
        {
            isPlaced = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Scannable"))
        {
            isPlaced = false;
        }
    }
}
