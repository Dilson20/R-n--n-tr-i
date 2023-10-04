using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawned : MonoBehaviour
{
    public GameObject[] spawnedObjects;
    public Vector3 minPosition;
    public Vector3 maxPosition;
    public Vector3 position;

    public float timer;
    public float spawnDelay;


    private void Start()
    {
        InvokeRepeating("Spawn", timer, spawnDelay);
    }

    private void Spawn()
    {
        int randomIndex = Random.Range(0, spawnedObjects.Length);
        Vector3 randomPosition = new Vector3(Random.Range(minPosition.x, maxPosition.x), position.y, Random.Range(minPosition.z, maxPosition.z));

        GameObject spawned = Instantiate(spawnedObjects[randomIndex], randomPosition, Quaternion.identity);
        Destroy(spawned, timer);
    
    }
}
