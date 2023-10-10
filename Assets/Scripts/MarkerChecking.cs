using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MarkerChecking : MonoBehaviour
{
    XRSocketInteractor socket;
    public List<GameObject> proteins;
    private List<Marker> markerComponents = new List<Marker>();
    private IXRSelectInteractable lastPlacedObject;

    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();

        // Fill the list of Tower components
        foreach (GameObject protein in proteins)
        {
            Marker marker = protein.GetComponent<Marker>();
            if (marker != null)
            {
                markerComponents.Add(marker);
            }
        }
    }

    public void OnObjectPlaced()
    {
        IXRSelectInteractable obj = socket.GetOldestInteractableSelected();

        if (tag == "MarkerA")
        {
            Marker markerA = GetMarkerComponent("MarkerA");
            if (markerA != null)
            {
                markerA.StartAction();
            }
        }
        else if (tag == "MarkerB")
        {
            Marker markerB = GetMarkerComponent("MarkerB");
            if (markerB != null)
            {
                markerB.StartAction();
            }
        }
        else if (tag == "MarkerC")
        {
            Marker markerC = GetMarkerComponent("MarkerC");
            if (markerC != null)
            {
                markerC.StartAction();
            }
        }


        lastPlacedObject = obj;

    }
    public void OnObjectExit()
    {

        if (lastPlacedObject != null)
        {
            string tag = lastPlacedObject.transform.tag;
            Marker maker = GetMarkerComponent(tag);

            if (maker != null)
            {
                maker.ExitAction();
            }

            // Clear the reference to the last placed object
            lastPlacedObject = null;
        }


    }

    // Find the Tower component based on the tag
    private Marker GetMarkerComponent(string tag)
    {
        foreach (Marker marker in markerComponents)
        {
            if (marker.CompareTag(tag))
            {
                return marker;
            }
        }
        return null;
    }
}
