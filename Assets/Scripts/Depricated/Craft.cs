using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Craft : MonoBehaviour
{
    XRSocketInteractor socket;
    public List<GameObject> resources; // List of resource objects
    private List<Resource> resourceComponents = new List<Resource>(); // List of Resource components
    private IXRSelectInteractable lastPlacedObject; // Reference to the last placed object

    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();

        // Populate the list of Resource components
        foreach (GameObject resourceObject in resources)
        {
            Resource resourceComponent = resourceObject.GetComponent<Resource>();
            if (resourceComponent != null)
            {
                resourceComponents.Add(resourceComponent);
            }
        }

        // Debug the number of resourceComponents found
        Debug.Log("Number of resourceComponents: " + resourceComponents.Count);
    }

    public void OnObjectPlaced()
    {
        IXRSelectInteractable placedObject = socket.GetOldestInteractableSelected();

        if (placedObject != null)
        {
            string objectTag = placedObject.transform.tag;
            if (objectTag == "ResourceA")
            {
                
                Resource resourceA = GetResourceComponent("ResourceA");
                if (resourceA != null)
                {

                    resourceA.ResourceAction1();
                }
            }
            else if (objectTag == "ResourceB")
            {
                Resource resourceB = GetResourceComponent("ResourceB"); // Change this to "ResourceB"
                if (resourceB != null)
                {
                    resourceB.ResourceAction2();
                }
            }

            // Update the reference to the last placed object
            lastPlacedObject = placedObject;
        }
    }


    public void OnObjectExit()
    {
        if (lastPlacedObject != null)
        {
            string objectTag = lastPlacedObject.transform.tag;
            Resource resource = GetResourceComponent(objectTag);

            if (resource != null)
            {
                //resource.ExitResourceAction();
            }

            // Clear the reference to the last placed object
            lastPlacedObject = null;
        }
    }

    // Helper method to find the Resource component based on the tag
    private Resource GetResourceComponent(string tag)
    {
        foreach (Resource resource in resourceComponents)
        {
            if (resource.CompareTag(tag))
            {
                return resource;
            }
        }
        return null;
    }
}
