using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{

    public AudioSource scanSounds;
    public AudioSource viruseA, viruseB, bacteria;

    public AudioClip scanButtonPress, scanButtonRelease, scanPickUp, scanInsert;
    public AudioClip virusPop;

    void Start()
    {
        
    }

    public void PickUpScannerSound()
    {

        scanSounds.clip = scanPickUp;
        scanSounds.Play();

    }

    public void InsertScannerSound()
    {

        scanSounds.clip = scanInsert;
        scanSounds.Play();

    }

    public void ScanButtonPressed()
    {

        scanSounds.clip = scanButtonPress;
        scanSounds.Play();

    }

    public void ViruseAPop()
    {

        viruseA.clip = virusPop;

    }

    public void ViruseBPop()
    {

        viruseB.clip = virusPop;

    }

    public void BacteriaPop()
    {

        bacteria.clip = virusPop;

    }
}
