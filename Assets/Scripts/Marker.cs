using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public bool isPlaced;
   public LayerMask Scannable;

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
        if (Scannable == (Scannable | (1 << other.gameObject.layer)))
        {
            isPlaced = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Scannable == (Scannable | (1 << other.gameObject.layer)))
        {
            isPlaced = false;
        }
    }
}
