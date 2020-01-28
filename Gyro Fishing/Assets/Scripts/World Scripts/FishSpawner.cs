using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject smolFishPrefab;
    public GameObject bigFishPrefab;

    private int randomSpawnType;
    private int randomSpawnPoint;
    public int fishMaxCount;
    public int currentFishCount;

    void Update() {
        if (currentFishCount < fishMaxCount)
            spawnFish();
    }

    void spawnFish()
    {
        randomSpawnType = Random.Range(0,2);
        randomSpawnPoint = Random.Range(0, spawnPoints.Length);

        if (randomSpawnType == 0)
            Instantiate(bigFishPrefab, spawnPoints[randomSpawnPoint].position, spawnPoints[randomSpawnPoint].rotation);
        if (randomSpawnType == 1)
            Instantiate(smolFishPrefab, spawnPoints[randomSpawnPoint].position, spawnPoints[randomSpawnPoint].rotation);

        currentFishCount++;
    }
}
