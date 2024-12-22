using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	[SerializeField] private GameObject chunkPrefab;
	[SerializeField] private int chunksAmount = 12;
	[SerializeField] private Transform chunksContainer;

	void Start()
	{
		var chunkSize = chunkPrefab.transform.GetChild(0).GetChild(0).localScale.z;
		
		for (int i = 0; i < chunksAmount; i++)
		{
			var chunkPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + i * chunkSize);
			
			Instantiate(chunkPrefab, chunkPosition, Quaternion.identity, chunksContainer);
		}
	}
}
