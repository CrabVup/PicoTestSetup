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

        // Populate the list of Tower components
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

        /*if (obj != null)
        {
            string tag = obj.transform.tag;
            if (tag == "TurretA")
            {
                // Find and invoke the StartTowerAction on the object with tag "TurretA"
                Tower towerA = GetTowerComponent("TurretA");
                if (towerA != null)
                {
                    towerA.StartTowerAction();
                }
            }
            else if (tag == "TurretB")
            {
                // Find and invoke the StartTowerAction on the object with tag "TurretB"
                Tower towerB = GetTowerComponent("TurretB");
                if (towerB != null)
                {
                    towerB.StartTowerAction();
                }
            }
            else if (tag == "TurretC")
            {
                // Find and invoke the StartTowerAction on the object with tag "TurretC"
                Tower towerC = GetTowerComponent("TurretC");
                if (towerC != null)
                {
                    towerC.StartTowerAction();
                }
            }*/
        if (tag == "MarkerA")
        {
            // Find and invoke the StartTowerAction on the object with tag "TurretC"
            Tower towerB = GetTowerComponent("MarkerA");
            if (towerB != null)
            {
                towerB.StartTowerAction();
            }
        }

        if (tag == "InfoA")
            {
                // Find and invoke the StartTowerAction on the object with tag "TurretC"
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


    // Helper method to find the Tower component based on the tag
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
