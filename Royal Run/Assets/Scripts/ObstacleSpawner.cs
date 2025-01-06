using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] float spawnInterval;
    [SerializeField] Transform obstaclesContainer;
    [SerializeField] private float spawnWidth = 4f;

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
            
            var obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            var obstaclePositionOffset = new Vector3(Random.Range(-spawnWidth, spawnWidth), 0, 0);
        
            Instantiate(obstaclePrefab, obstaclesContainer.position + obstaclePositionOffset, Random.rotation, obstaclesContainer);
        }
    }
}
