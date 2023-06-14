using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{   
    public GameObject objectToSpawn;       // The game object to spawn
    public float minSpawnInterval = 2f;    // The minimum spawn interval
    public float maxSpawnInterval = 4f;    // The maximum spawn interval
    public Transform spawnPoint;           // The position to spawn the objects

    private float timer = 0f;              // Timer to track spawn intervals
    private float spawnInterval = 0f;       // Random spawn interval

    private void Start()
    {
        // Generate a random spawn interval on Start
        GenerateSpawnInterval();
    }

    private void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if the timer exceeds the spawn interval
        if (timer >= spawnInterval)
        {
            // Reset the timer
            timer = 0f;

            // Spawn the object
            SpawnObject();

            // Generate a new random spawn interval
            GenerateSpawnInterval();
        }
    }

    private void GenerateSpawnInterval()
    {
        // Generate a random spawn interval between the min and max values
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void SpawnObject()
    {
        // Instantiate the object at the spawn point
        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}

