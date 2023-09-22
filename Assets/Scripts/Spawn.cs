using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject Button;
    public GameObject Fighter;
    public GameObject Tower;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnFighter()
    {
        Vector3 pos = Button.transform.position;
       // if()
     //  {
            Instantiate(Fighter, pos, Quaternion.identity);
        //}
       
    }
    public void SpawnTower()
    {
        Vector3 pos = Button.transform.position;
       // if ()
        //{
            Instantiate(Tower, pos, Quaternion.identity);
      //  }
    }
}
