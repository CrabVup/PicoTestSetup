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

    public GameObject VirusA;
    public GameObject VirusB;
    public GameObject VirusC;
    public string VirusID;

    void Start()
    {
        notFinishedIcon.SetActive(false);
        finishedIcon.SetActive(false);
        VirusA.SetActive(false);
        VirusB.SetActive(false);
        VirusC.SetActive(false);
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
        virusDescription1.text = "Encode\n: " + scannedVirus.GetEncode();
            virusDescription2.text = "Lifetime\n: " + scannedVirus.GetLifetime();
            virusDescription3.text = "Amount\n: " + scannedVirus.GetSize();
        virusDescription4.text = "Infectivity\n: " + scannedVirus.GetInfectivity();
            VirusID = scannedVirus.GetID();

            if (VirusID == "A")
            {
                VirusA.SetActive(true);
            }
            if (VirusID == "B")
            {
                VirusB.SetActive(true);
            }
            if (VirusID == "C")
            {
                VirusC.SetActive(true);
            }
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
