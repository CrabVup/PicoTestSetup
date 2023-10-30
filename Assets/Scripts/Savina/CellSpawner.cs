using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    public GameObject spawnCell;
    public float frequency;
    public float initialSpeed;
    float lastSpawnTime;
    void Update()
    {
        if (Time.time > lastSpawnTime + frequency)
        {
            // Spawn of the cells
            Instantiate(spawnCell, transform.position, Quaternion.identity);
            lastSpawnTime = Time.time;
        }
    }
}
