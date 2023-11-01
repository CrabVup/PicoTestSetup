using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float enemyInerval = 2f;

    void Start()
    {
        StartCoroutine(spawnEnemy(enemyInerval, enemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-1f, 1f), 0.5f, Random.Range(0, 2f)), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
