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
    Transform spawnPoints;
    [SerializeField]
    GameObject Player;

    [SerializeField]
    float minimumSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnMeteor), 1f,timeBWSpawn);
        InvokeRepeating(nameof(DecreaseSpawnTime), 4, 5);
    }
   void SpawnMeteor()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-2f, 2f),spawnPoints.position.y , 0);
        Instantiate(meteorPrefab[Random.Range(0,meteorPrefab.Length)],spawnPoint,Quaternion.identity);
        if (Player == null)
            CancelInvoke();
    }

    void DecreaseSpawnTime()
    {
        if (timeBWSpawn > minimumSpawnTime)
            timeBWSpawn -= Time.deltaTime*4f;
    }
}
        