using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Qs : MonoBehaviour
{
    // TICK MARK 
    public Image scan_tick;
    public Image craft_tick;
    public Image kill_tick;

    // THE TEXTS 0/1 - 1/3
    public TextMeshProUGUI scan_count;
    public TextMeshProUGUI craft_count;
    public TextMeshProUGUI kill_count;

    public int scanned_counter;

    // LISTS OF THE PREFABS
    public List<GameObject> TCells1 = new List<GameObject>();
    public List<GameObject> TCells2 = new List<GameObject>();
    public List<GameObject> TCells3 = new List<GameObject>();

    // PANELS
    public Image panel1;
    public Image panel2;
    public Image panel3;

    // VIRUSES SCANNED
    public Scan scanScript;

    public GameObject virusA;


    // Start is called before the first frame update
    void Start()
    {
        scanned_counter = 0;

        scan_count.text = scanned_counter.ToString();
        craft_count.text = scanned_counter.ToString();
        kill_count.text = scanned_counter.ToString();

        scan_tick = GameObject.Find("tickMark").GetComponent<Image>();
        craft_tick = GameObject.Find("tickMark (1)").GetComponent<Image>();
        kill_tick = GameObject.Find("tickMark (2)").GetComponent<Image>();

        panel1 = GameObject.Find("Quest1").GetComponent<Image>();
        panel2 = GameObject.Find("Quest2").GetComponent<Image>();
        panel3 = GameObject.Find("Quest3").GetComponent<Image>();

        scan_tick.enabled = false;
        craft_tick.enabled = false;
        kill_tick.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        /* if (virusA.GetComponent<Virus>().isScanned == true scan_tick.enabled == false) // RANDOM IF 
         {
             scan_count.text = scanned_counter.ToString();
             if (scan_count.text == "3/3")
             {
                 scan_tick.enabled = true;
                 panel1.color = UnityEngine.Color.green;
             }
         }*/

        bool isScanned = virusA.GetComponent<Virus>().IsScanned();

        if (!isScanned)
        {
            scan_count.text = scanned_counter.ToString();
            if (scan_count.text == "3/3")
            {
                scan_tick.enabled = true;
                panel1.color = UnityEngine.Color.green;
            }
        }

        if (GameObject.FindWithTag("PushButton").GetComponent<CraftingSystem>().isCrafted == true)
        {
            craft_tick.enabled = true;
            craft_count.text = "1/3";
            panel2.color = UnityEngine.Color.green;
        }

        Cells1();
        Cells2();
        Cells3();
    }

    public void Cells1()
    {
       VirusTcell[] tCells = FindObjectsOfType<VirusTcell>();

        // Clear the existing list as we are going to update it.
        TCells1.Clear();

        // Create a set to keep track of markers you've already processed.
        HashSet<VirusTcell> hastcell = new HashSet<VirusTcell>();

        foreach (VirusTcell tCell in tCells)
        {
            // Check if we've already processed this marker.
            if (!hastcell.Contains(tCell))
            {
                TCells1.Add(tCell.gameObject);

                // Add the marker to the set of processed markers.
                hastcell.Add(tCell);
            }
        }

        foreach (GameObject TCell1 in TCells1)
        {
            VirusTcell virusTcell = TCell1.GetComponent<VirusTcell>();

            if (virusTcell.isKilled)
            {
                kill_tick.enabled = true;
                kill_count.text = "1/3";
                panel3.color = UnityEngine.Color.green;
            }
        }
    }
    
    public void Cells2()
    {
        VirusTcell2[] tCells2 = FindObjectsOfType<VirusTcell2>();

        // Clear the existing list as we are going to update it.
        TCells2.Clear();

        // Create a set to keep track of markers you've already processed.
        HashSet<VirusTcell2> hastcell2 = new HashSet<VirusTcell2>();

        foreach (VirusTcell2 tCell2 in tCells2)
        {
            // Check if we've already processed this marker.
            if (!hastcell2.Contains(tCell2))
            {
                TCells2.Add(tCell2.gameObject);

                // Add the marker to the set of processed markers.
                hastcell2.Add(tCell2);
            }
        }

        foreach (GameObject TCell2 in TCells2)
        {
            VirusTcell2 virusTcell2 = TCell2.GetComponent<VirusTcell2>();

            if (virusTcell2.isKilled)
            {
                kill_tick.enabled = true;
                kill_count.text = "1/3";
                panel3.color = UnityEngine.Color.green;
            }
        }
    }

    public void Cells3()
    {
        VirusTcell3[] tCells3 = FindObjectsOfType<VirusTcell3>();

        // Clear the existing list as we are going to update it.
        TCells3.Clear();

        // Create a set to keep track of markers you've already processed.
        HashSet<VirusTcell3> hastcell3 = new HashSet<VirusTcell3>();

        foreach (VirusTcell3 tCell3 in tCells3)
        {
            // Check if we've already processed this marker.
            if (!hastcell3.Contains(tCell3))
            {
                TCells3.Add(tCell3.gameObject);

                // Add the marker to the set of processed markers.
                hastcell3.Add(tCell3);
            }
        }

        foreach (GameObject TCell3 in TCells3)
        {
            VirusTcell3 virusTcell3 = TCell3.GetComponent<VirusTcell3>();

            if (virusTcell3.isKilled)
            {
                kill_tick.enabled = true;
                kill_count.text = "1/3";
                panel3.color = UnityEngine.Color.green;
            }
        }
    }
}
