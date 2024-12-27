using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float spawnInterval;

    void Start()
    {
        var coroutine = SpawnObstaclesInInterval();
        
        StartCoroutine(coroutine);
    }

    IEnumerator SpawnObstaclesInInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
        
            Instantiate(obstaclePrefab, transform.position, Random.rotation);
        }
    }
}
