using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    public GameObject spawnCell;
    public float frequency;
    public float initialSpeed;
    public Transform plane; // Reference to the plane where you want to spawn cells
    public Vector2 spawnAreaSize; // Define the size of the area on the plane where cells will spawn

    float lastSpawnTime;

    void Update()
    {
        if (Time.time > lastSpawnTime + frequency)
        {
            // Calculate random spawn position within the defined area
            Vector3 randomSpawnPosition = new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                0.0f,
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2)
            );

            // Convert local position to world position using the plane's transform
            Vector3 worldSpawnPosition = plane.TransformPoint(randomSpawnPosition);

            // Spawn the cells at the calculated position
            Instantiate(spawnCell, worldSpawnPosition, Quaternion.identity);

            lastSpawnTime = Time.time;
        }
    }
}
