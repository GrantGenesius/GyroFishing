using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject waterPrefab;
    public float delayTime;
    public float repeatRate;
    public int randomRange;

    void Start()
    {
        InvokeRepeating("SpawnObject", delayTime, repeatRate);
    }

    void SpawnObject() {
        StartCoroutine(SpawnRandomTime());
    }

    public IEnumerator SpawnRandomTime(){
        int randomTime = Random.Range(0, randomRange);
        yield return new WaitForSeconds(randomTime);
        Instantiate(waterPrefab, transform.position, transform.rotation);
    }

}
