using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float spawnInterval;

    void Start()
    {
        var coroutine = SpawnObstaclesInInterval(5, spawnInterval);
        
        StartCoroutine(coroutine);
    }

    IEnumerator SpawnObstaclesInInterval(int obstacleCount, float seconds)
    {
        for (var i = 0; i < obstacleCount; i++)
        {
            yield return new WaitForSeconds(seconds);
        
            Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        }
    }
}
