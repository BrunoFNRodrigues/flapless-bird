using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{   
    public GameObject objectToSpawn;       
    public float minSpawnInterval = 2f;    
    public float maxSpawnInterval = 4f;    
    public Transform spawnPoint;

    private float timer = 0f;             
    private float spawnInterval = 0f;

    public GameObject manager;

    public bool stop = false;

    private void Start()
    {
        GenerateSpawnInterval();
        manager = GameObject.Find("GameManager");
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;

            SpawnObject();

            GenerateSpawnInterval();
        }
    }

    private void GenerateSpawnInterval()
    {
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void SpawnObject()
    {
        if(!manager.GetComponent<Manager>().stopSign)
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}

