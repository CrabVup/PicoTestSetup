using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class Flashlight : MonoBehaviour
{
    public Material lens;

    public Light _light;
    //private AudioSource _audioSource;

    void Start()
    {
        _light = GetComponentInChildren<Light>();
        //_audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
       
    }
    public void LightOn()
    {
        //_audioSource.Play();
        lens.EnableKeyword("_EMISSION");
        _light.enabled = true;
    }

    public void LighOff()
    {
       // _audioSource.Play();
        lens.DisableKeyword("_EMISSION");
        _light.enabled = false;
        
    }

}
