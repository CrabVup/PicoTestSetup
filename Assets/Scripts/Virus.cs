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

    public override string ToString()
    {
        return $"Encode: {Encode}, Lifetime: {Lifetime}, Amount: {Amount}, Infectivity: {Infectivity}, VirusName: {VirusName}";
    }
}

public class Virus : MonoBehaviour
{

    public CalculateDistance calculateDistance;
    public PlayerHealth playerHealth;
    [SerializeField]
    public VirusInfo info;
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
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VirusA"))
        {
            GetComponent<AudioSource>().Play();
            playerHealth.Increase();
            Destroy(this.gameObject);
            calculateDistance.virusADestroyed = true; // this is only for virus a, u'll need to add those tags for the other two viruses
        }
    }
}
