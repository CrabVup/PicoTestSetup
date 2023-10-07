using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct VirusInfo
{
    public string Name;
    public string Gender;
    public float Size;
    public override string ToString()
    {
            return $"name {Name}, size: {Size}, gender: {Gender}";  
    }
}
public class Virus : MonoBehaviour
{
    [SerializeField]
    public VirusInfo info;
    public VirusInfo GetInformation()
    {
        return info;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VirusA"))
        {
            Destroy(this.gameObject);
        }
    }
}
