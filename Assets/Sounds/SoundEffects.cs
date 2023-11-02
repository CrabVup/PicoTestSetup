using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{

    public AudioSource scanSource;
    public AudioSource viruseA, viruseB, bacteria;

    public AudioClip scanButtonPress, scanButtonRelease, scanInsert;
    public AudioClip virusPop;

    public void InsertScannerSound()
    {

        scanSource.clip = scanInsert;
        scanSource.Play();

    }

    public void ScanButtonPressed()
    {

        scanSource.clip = scanButtonPress;
        scanSource.Play();

    }

    public void ScanButtonExit()
    {

        scanSource.clip = scanButtonRelease;
        scanSource.Play();

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
