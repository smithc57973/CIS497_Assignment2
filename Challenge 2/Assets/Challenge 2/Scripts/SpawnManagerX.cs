/*
* Chris Smith
* Challenge 2
* Manages ball spawn rate and position
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    public HealthSystem healthsystem;
    public DisplayScore displayscore;

    // Start is called before the first frame update
    void Start()
    {
        //get reference to health system
        healthsystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();

        //get reference to display score
        displayscore = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();

        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
        StartCoroutine(SpawnCoroutine());
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        int index = Random.Range(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[index], spawnPos, ballPrefabs[index].transform.rotation);
    }

    IEnumerator SpawnCoroutine()
    {
        //add a 3 second delay in beginning
        yield return new WaitForSeconds(3f);

        //spawn at random intervals
        while (!healthsystem.gameOver)
        {
            if (displayscore.gameOver)
            {
                break;
            }
            SpawnRandomBall();
            float randomDelay = Random.Range(3.0f, 5.0f);
            yield return new WaitForSeconds(randomDelay);
        }
    }

}
