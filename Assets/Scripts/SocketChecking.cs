using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class SocketChecking : MonoBehaviour
{

    XRSocketInteractor socket;
    public List<GameObject> Turrets;

    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
        foreach (GameObject turret in Turrets)
        {
            Tower tower = turret.GetComponent<Tower>();
            if (tower != null)
            {
                // You have found the Tower script on the GameObject 'turret'
                // You can now work with 'tower'
            }
        }
    }

    public void socketCheck()
    {

        IXRSelectInteractable objName = socket.GetOldestInteractableSelected();
        Debug.Log(objName.transform.name + " in socket of " + transform.name);

    }

    public void OnObjectPlaced()
    {
        
        IXRSelectInteractable obj = socket.GetOldestInteractableSelected();

        if(obj.transform.tag == "TurretA")
        {
            
            Debug.Log("A");
        }

        if (obj.transform.tag == "TurretB")
        {
           
            Debug.Log("B");
        }

        if (obj.transform.tag == "TurretC")
        {
          
            Debug.Log("C");
        }


    }
}