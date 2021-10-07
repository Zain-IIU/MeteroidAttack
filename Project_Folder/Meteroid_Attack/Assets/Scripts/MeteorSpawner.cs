using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField]
    float timeBWSpawn;
    Vector3 spawnPos;
    [SerializeField]
    GameObject[] meteorPrefab;

    [SerializeField]
    Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnMeteor), 1f,timeBWSpawn);
    }
   void SpawnMeteor()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-2.5f, 2.5f), 6, 0);
        Instantiate(meteorPrefab[Random.Range(0,meteorPrefab.Length)],spawnPoint,Quaternion.identity);
    }
}
        