using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Qs : MonoBehaviour
{
    public Image scan_tick;
    public Image craft_tick;
    public Image kill_tick;
    public TextMeshProUGUI scan_count;
    public TextMeshProUGUI craft_count;
    public TextMeshProUGUI kill_count;

    private void Awake()
    {
        scan_tick = GetComponent<UnityEngine.UI.Image>();
        craft_tick = GetComponent<UnityEngine.UI.Image>();
        kill_tick = GetComponent<UnityEngine.UI.Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
       scan_count.text = "0/1";
       craft_count.text = "0/1";
       kill_count.text = "0/1";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("XR Origin").GetComponent<ZG>().isScanned == true)
        {
            scan_tick.enabled = true;
            scan_count.text = "1/1";
        }

        if (GameObject.Find("Push Button").GetComponent<CraftingSystem>().isCrafted == true)
        {
            craft_tick.enabled = true;
            craft_count.text = "1/1";
        }

        if ((GameObject.Find("T-Cell 1").GetComponent<VirusTcell>().isKilled == true) || (GameObject.Find("T-Cell 1 (1)").GetComponent<VirusTcell>().isKilled == true) || (GameObject.Find("T-Cell 1 (2)").GetComponent<VirusTcell>().isKilled == true) || (GameObject.Find("T-Cell 1 (3)").GetComponent<VirusTcell>().isKilled == true))
        {
            kill_tick.enabled = true;
            kill_count.text = "1/1";
        }
    }
}
