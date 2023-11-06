using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct VirusInfo
{
    public string Encode;
    public string Lifetime;
    public string Amount;
    public string Infectivity;
    public string VirusName;
    public bool isScanned;
    public override string ToString()
    {
        return $"Encode: {Encode}, Lifetime: {Lifetime}, Amount: {Amount}, Infectivity: {Infectivity}, VirusName: {VirusName}";
    }
}

public class Virus : MonoBehaviour
{
    [SerializeField]
    public VirusInfo info;

    public bool IsScanned()
    {
        return info.isScanned;
    }

    public void MarkAsScanned()
    {
        info.isScanned = true;
    }

    public void MarkAsNotScanned()
    {
        info.isScanned = false;
    }

    public string GetID()
    {
        return info.VirusName;
    }

    public string GetEncode()
    {
        return info.Encode;
    }

    public string GetLifetime()
    {
        return info.Lifetime;
    }

    public string GetSize()
    {
        return info.Amount;
    }

    public string GetInfectivity()
    {
        return info.Infectivity;
    }

    public void Start()
    {
        // You can start with isScanned as false
        info.isScanned = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Handle collision or scanning events
        // When the virus is scanned, call MarkAsScanned() to update the scanning status.
    }

    private void OnTriggerExit(Collider other)
    {
        // Handle events when the scanner or player exits the virus's proximity.
        // You might call MarkAsNotScanned() here if needed.
    }
}
