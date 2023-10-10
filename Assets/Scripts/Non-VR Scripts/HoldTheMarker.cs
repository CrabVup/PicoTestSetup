using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldTheMarker : MonoBehaviour
{
    Vector3 mousePosition;

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    /*void Start()
    {
        mainCamera = Camera.main;
    }
    */

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }

    /*
    Vector3 ScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position);
    Vector3 NewWorldPosition = mainCamera.ScreenToWorldPoint(ScreenPosition); // Screen point converted to world point
    transform.position = NewWorldPosition;
    */
}
