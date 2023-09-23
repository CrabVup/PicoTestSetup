using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketExit : MonoBehaviour
{

    XRSocketInteractor socket;
    public List<GameObject> turrets;
    private List<Tower> towerComponents = new List<Tower>();

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
    public void OnObjectExit()
    {
        IXRSelectInteractable obj = socket.GetOldestInteractableSelected();

        if (obj == null)
        {
            Debug.LogWarning("obj is null");
        }
        else
        {
            string tag = obj.transform.tag;
            Tower tower = GetTowerComponent(tag);

            if (tower != null)
            {
                tower.ExitTowerAction();
            }
        }
    }



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
