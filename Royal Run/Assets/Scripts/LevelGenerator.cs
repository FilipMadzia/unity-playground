using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	[SerializeField] GameObject chunkPrefab;
	[SerializeField] int initialChunksAmount = 12;
	[SerializeField] Transform chunksContainer;
	[SerializeField] float chunkSpeed = 8f;

	readonly List<GameObject> _chunks = new();
	Camera _camera;

	void Start()
	{
		_camera = Camera.main;
		
		SpawnInitialChunks();
	}

	void Update()
	{
		MoveChunks();
	}

	void SpawnInitialChunks()
	{
		for (var i = 0; i < initialChunksAmount; i++)
		{
			SpawnChunk();
		}
	}

	void MoveChunks()
	{
		var chunksCopy = _chunks.ToList();
		
		foreach (var chunk in chunksCopy)
		{
			chunk.transform.Translate(-transform.forward * (chunkSpeed * Time.deltaTime));
			
			var isChunkBehindCamera = chunk.transform.position.z <= _camera.transform.position.z;

			if (isChunkBehindCamera)
			{
				RemoveChunk(chunk);
				
				SpawnChunk();
			}
		}
	}
	
	void SpawnChunk()
	{
		var newChunkPosition = _chunks.Count == 0 ? new Vector3(0, 0, 0) : GetNewChunkPosition(_chunks.Last());
		
		var newChunk = Instantiate(chunkPrefab, newChunkPosition, Quaternion.identity, chunksContainer);
		
		_chunks.Add(newChunk);
	}

	void RemoveChunk(GameObject chunk)
	{
		_chunks.Remove(chunk);
		Destroy(chunk);
	}

	float GetChunkSize() => chunkPrefab.transform.GetChild(0).GetChild(0).localScale.z;
	
	Vector3 GetNewChunkPosition(GameObject previousChunk) => new(previousChunk.transform.position.x, transform.position.y, previousChunk.transform.position.z + GetChunkSize());
}
