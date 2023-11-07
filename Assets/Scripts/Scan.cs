using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scan : MonoBehaviour
{
    public bool isScanned;
    public GameObject scannableIcon;

    public GameObject lostTrackIcon;
    public GameObject finishedIcon;

    public Image scanningBar;

    public float fillSpeed = 1f; 
    public float currentValue;

    public TMP_Text virusDescription1;
    public TMP_Text virusDescription2;
    public TMP_Text virusDescription3;
    public TMP_Text virusDescription4;

    public GameObject VirusA;
    public GameObject VirusB;
    public GameObject VirusC;
    public string VirusID;

    public GameObject distanceA;
    public GameObject distanceB;
    public GameObject distanceC;

    public AudioSource scanFail, scanSuccess, firstScan;

    public int scannedViruses;

    public bool isTracked;

    public GameObject scanner;

    //public PlayerHealth playerHealth;

    //public List<GameObject> VirusesA = new List<GameObject>();

    void Start()
    {
        scannableIcon.SetActive(false);
        finishedIcon.SetActive(false);
        VirusA.SetActive(false);
        VirusB.SetActive(false);
        VirusC.SetActive(false);
        lostTrackIcon.SetActive(false);

        scannedViruses = 0;
}

  
    void Update()
    {
        scanningBar.fillAmount = currentValue / 100f;
        if (Input.GetButton("Fire3"))
        {
            currentValue = 0;
            VirusA.SetActive(false);
            VirusB.SetActive(false);
            VirusC.SetActive(false);
            distanceA.SetActive(true);
            distanceB.SetActive(true);
            distanceC.SetActive(true);
            lostTrackIcon.SetActive(false);
            isTracked = false;
            scanFail.Play();
            Debug.Log("222");
        
        }
       
     
        if (isScanned == true)
        {
            scannableIcon.SetActive(true);
            distanceA.SetActive(false);
            distanceB.SetActive(false);
            distanceC.SetActive(false);
            lostTrackIcon.SetActive(false);
            scanningBar.color = Color.green;
            isTracked = true;
            
        }
        else
        {
            scannableIcon.SetActive(false);
            scanningBar.color = Color.red;
          
            if (isTracked)
            {
                lostTrackIcon.SetActive(true);
               // scanFail.Play();
            }

        }

        if (currentValue == 0)
        {
            finishedIcon.SetActive(false);
            scanningBar.fillAmount = 0;

        }

        if (currentValue == 100)
        {
            finishedIcon.SetActive(true);
            scannableIcon.SetActive(false);
            lostTrackIcon.SetActive(false);
            scanningBar.color = Color.green;
            isTracked = false;
           // scanSuccess.Play();

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
          if (other.gameObject.layer == LayerMask.NameToLayer("Scannable"))
            {
                 isScanned = true;
    
            }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Scannable"))
        {
           isScanned = false;
           // scanFail.Play();
           if (isTracked)
            {
                scanFail.Play();
            }
        }
    }
    public void GetInfo()
    {
        if (isScanned == true)
        {
            currentValue += fillSpeed * Time.deltaTime;
            currentValue = Mathf.Clamp(currentValue, 0f, 100f);
            scanningBar.fillAmount = currentValue / 100f;
            if (currentValue >= 100)
            {
                scanSuccess.Play();
                FirstScannedVirusAudio();
            } else
            { 
                if (currentValue == 100)
                {
                    if (VirusID == "A")
                    {
                        GameObject.FindWithTag("VirusA").GetComponent<Virus>().MarkAsScanned();

                    }
                    if (VirusID == "B")
                    {
                        GameObject.FindWithTag("VirusB").GetComponent<Virus>().MarkAsScanned();
                    }
                    if (VirusID == "C")
                    {
                        GameObject.FindWithTag("bacteria").GetComponent<Virus>().MarkAsScanned();
                    }
                }
            }
        }
    }

    public void FirstScannedVirusAudio()
    {
        scannedViruses += 1;

        if (scannedViruses == 1)
        {

            firstScan.Play();

        }
    }

    /*
    public void Avirus()
    {
        Virus[] aViruses = FindObjectsOfType<Virus>();

        VirusesA.Clear();

        HashSet<Virus> aV = new HashSet<Virus>();

        foreach (Virus aViruse in aViruses)
        {
            if (!aV.Contains(aViruse))
            {
                VirusesA.Add(aViruse.gameObject);

                aV.Add(aViruse);
            }
        }

        scanner.GetComponent<Virus>().MarkAsScanned();
    }*/
}
