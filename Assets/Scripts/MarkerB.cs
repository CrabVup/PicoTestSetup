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
        Destroy(this.gameObject);
        Debug.Log("isOut");

    }
}
