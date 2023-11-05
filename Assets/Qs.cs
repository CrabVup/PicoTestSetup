using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Qs : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI scan_count;

    private void Awake()
    {
        image = GetComponent<UnityEngine.UI.Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
       scan_count.text = "0/1";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("XR Origin").GetComponent<ZG>().isScanned == true)
        {
            image.enabled = true;
            scan_count.text = "1/1";
        }
    }
}
