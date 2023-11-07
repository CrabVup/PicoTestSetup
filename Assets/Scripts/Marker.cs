using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public bool isPlaced;
    //public bool isCrafted;

    /*
    public struct MarkerInfo
    {
        public string MarkerName;
    }

    [SerializeField]
    public MarkerInfo info;

    public override string ToString()
    {
        return $"MarkerName: {MarkerName}";
    }

    public string GetID()
    {
        return info.MarkerName;
    }
    */
    public void StartAction()
    {
        isPlaced = true;
        //isCrafted = false;
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
    /*
    public void MarkAsCrafted()
    {
        isCrafted = true;
    }
    */
}

