using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	[SerializeField] private GameObject chunkPrefab;
	[SerializeField] private int chunksAmount = 12;
	[SerializeField] private Transform chunksContainer;
	[SerializeField] private float chunkSpeed = 8f;
	
	GameObject[] _chunks;

	void Start()
	{
		_chunks = new GameObject[chunksAmount];
		
		SpawnChunks();
	}

	void Update()
	{
		MoveChunks();
	}

	void SpawnChunks()
	{
		var chunkSize = GetChunkSize();
		
		for (var i = 0; i < chunksAmount; i++)
		{
			var chunkPosition = GetChunkPosition(i, chunkSize);
			
			var newChunk = Instantiate(chunkPrefab, chunkPosition, Quaternion.identity, chunksContainer);
			
			_chunks[i] = newChunk;
		}
	}

	void MoveChunks()
	{
		for (var i = 0; i < chunksAmount; i++)
		{
			_chunks[i].transform.Translate(-transform.forward * (chunkSpeed * Time.deltaTime));
		}
	}

	float GetChunkSize() => chunkPrefab.transform.GetChild(0).GetChild(0).localScale.z;
	
	Vector3 GetChunkPosition(int chunkIndex, float chunkSize) => new Vector3(transform.position.x, transform.position.y, transform.position.z + chunkIndex * chunkSize);
}
