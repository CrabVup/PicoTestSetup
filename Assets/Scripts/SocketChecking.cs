using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketChecking : MonoBehaviour
{
    XRSocketInteractor socket;
    public List<GameObject> turrets;
    private List<Tower> towerComponents = new List<Tower>();
    private IXRSelectInteractable lastPlacedObject;

    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();

        // Fill the list of Tower components
        foreach (GameObject turret in turrets)
        {
            Tower tower = turret.GetComponent<Tower>();
            if (tower != null)
            {
                towerComponents.Add(tower);
            }
        }
    }

    public void OnObjectPlaced()
    {
        IXRSelectInteractable obj = socket.GetOldestInteractableSelected();

        if (tag == "InfoA")
            {
                Tower towerA = GetTowerComponent("InfoA");
                if (towerA != null)
                {
                      towerA.StartTowerAction();
                }
            }
            lastPlacedObject = obj;
        
    }
    public void OnObjectExit()
    {

        if (lastPlacedObject != null)
        {
            string tag = lastPlacedObject.transform.tag;
            Tower tower = GetTowerComponent(tag);

            if (tower != null)
            {
                tower.ExitTowerAction();
            }

            // Clear the reference to the last placed object
            lastPlacedObject = null;
        }
    }

    // Find the Tower component based on the tag
    private Tower GetTowerComponent(string tag)
    {
        foreach (Tower tower in towerComponents)
        {
            if (tower.CompareTag(tag))
            {
                return tower;
            }
        }
        return null;
    }
}
