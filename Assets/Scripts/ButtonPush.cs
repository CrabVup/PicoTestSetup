using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPush : MonoBehaviour
{
    public Animator animator;
   // public string boolName = "open";
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ToggleDoorOpen());
    }

    void Update()
    {
        
    }

    public void ToggleDoorOpen()
    {
        bool isOpen = animator.GetBool("open");
        animator.SetBool("open", !isOpen);
    }
}
