using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Qs : MonoBehaviour
{
    public Image image;

    private void Awake()
    {
        image = GetComponent<UnityEngine.UI.Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("XR Origin").GetComponent<ZG>().isScanned == true)
        {
            image.enabled = true;
        }
    }
}
