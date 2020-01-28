using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject smolBoat;
    public GameObject bigBoat;

    public float delayTime;
    public float repeatRate;

    //random variables
    private int randomSpawnPoint;
    private int randomSpawnType;

    //number of times a boat spawns
    public int spawnCount;

    //adjusts game difficulty over time
    public int currentDifficulty;
    public float gameTime;

    void Start()
    {
        InvokeRepeating("SpawnHazard", delayTime, repeatRate);
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        //increase difficulty every 10 seconds by increasing boat spawn count, also difficulty limit is 10
        if(gameTime / 20 >= currentDifficulty && currentDifficulty <= 10){
            currentDifficulty++;
            spawnCount += 2;
        }
    }

    void SpawnHazard() 
    {
        StartCoroutine(SpawnHazardRandomly());
    }

    IEnumerator SpawnHazardRandomly() {
        float randomedTime = Random.Range(0, delayTime);
        yield return new WaitForSeconds(randomedTime);

        //random boat type and spawnpoint
        for (int i = 0; i < spawnCount; i++)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomSpawnType = Random.Range(0, 2);
            if (randomSpawnType == 1)
                Instantiate(smolBoat, spawnPoints[randomSpawnPoint].position, spawnPoints[randomSpawnPoint].rotation);
            if (randomSpawnType == 0)
                Instantiate(bigBoat, spawnPoints[randomSpawnPoint].position, spawnPoints[randomSpawnPoint].rotation);
        }
        
    }
}
