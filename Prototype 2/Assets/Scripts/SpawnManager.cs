/*
* Chris Smith
* Prototype 2
* Manages animal spawn rate and location
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //set the array of references in the inspector
    public GameObject[] prefabsToSpawn;
    private float leftBound = -14;
    private float rightBound = 14;
    private float spawnPosZ = 20;

    public HealthSystem healthsystem;

    void Start()
    {
        //get reference to health system
        healthsystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();

        //InvokeRepeating("SpawnRandomPrefab", 2, 1.5f);
        StartCoroutine(SpawnCoroutine());
    }

    void SpawnRandomPrefab()
    {
        //Pick a random animal
        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

        //Pick a random position
        Vector3 spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, spawnPosZ);

        //Spawn animal
        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);
    }

    IEnumerator SpawnCoroutine()
    {
        //add a 3 second delay in beginning
        yield return new WaitForSeconds(3f);

        //spawn at random intervals
        while (!healthsystem.gameOver)
        {
            SpawnRandomPrefab();
            float randomDelay = Random.Range(0.8f, 3.0f);
            yield return new WaitForSeconds(randomDelay);
        }
    }
}
