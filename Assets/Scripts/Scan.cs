using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scan : MonoBehaviour
{
    public bool isScanned;
    public GameObject notFinishedIcon;
    public GameObject finishedIcon;

    public Image scanningBar;
    public float fillSpeed = 1f; 
    public float currentValue = 0f;
    void Start()
    {
        notFinishedIcon.SetActive(false);
        finishedIcon.SetActive(false);
    }

  
    void Update()
    {
        if (isScanned == true)
        {
            notFinishedIcon.SetActive(true);
        }else
        {
            notFinishedIcon.SetActive(false);
        }

        if (currentValue == 100)
        {
            finishedIcon.SetActive(true);
            notFinishedIcon.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
          if (other.CompareTag("VirusA"))
            {
                 isScanned = true;
            }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("VirusA"))
        {
                 isScanned = false;
        }
    }
    public void GetInfo()
    {
        if (isScanned == true)
        {
            currentValue += fillSpeed * Time.deltaTime;
            currentValue = Mathf.Clamp(currentValue, 0f, 100f);
            scanningBar.fillAmount = currentValue / 100f;
        }
    }
}
