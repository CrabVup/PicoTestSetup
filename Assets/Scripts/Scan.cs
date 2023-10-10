using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scan : MonoBehaviour
{
    public bool isScanned;
    public GameObject notFinishedIcon;
    public GameObject finishedIcon;

    public Image scanningBar;
    public float fillSpeed = 1f; 
    public float currentValue = 0f;

    public TMP_Text virusDescription1;
    public TMP_Text virusDescription2;
    public TMP_Text virusDescription3;
    public TMP_Text virusDescription4;
    void Start()
    {
        notFinishedIcon.SetActive(false);
        finishedIcon.SetActive(false);
    }

  
    void Update()
    {
        if (Input.GetButton("Fire3"))
        {
            currentValue = 0;
            Debug.Log("222");
        }
        if (isScanned == true)
        {
            notFinishedIcon.SetActive(true);
        }else
        {
            notFinishedIcon.SetActive(false);
        }

        if (currentValue == 0)
        {
            finishedIcon.SetActive(false);
            scanningBar.fillAmount = 0;

        }

        if (currentValue == 100)
        {
            finishedIcon.SetActive(true);
            notFinishedIcon.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Virus>(out Virus scannedVirus))
        {
            virusDescription1.text = "Information\n" + (scannedVirus.GetInformation());
            virusDescription2.text = "Information\n" + (scannedVirus.GetInformation());
            virusDescription3.text = "Information\n" + (scannedVirus.GetInformation());
            virusDescription4.text = "Information\n" + (scannedVirus.GetInformation());
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
