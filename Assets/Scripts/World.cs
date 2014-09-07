using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parse;
using System.Threading.Tasks;

public class World : MonoBehaviour 
{
	public static World instance;
	public List<Chunk> chunks = new List<Chunk>();
	public GameObject piecePrefab;


	void Awake()
	{
		instance = this;
	}


	void Start()
	{
		GenerateWorld(new Vector3(4,4,4));
	}



	void GenerateWorld(Vector3 sizeInChunks)
	{
		// Loop over each dimension's length.
		for (int z = 0; z < sizeInChunks.x; z++)
		{
			for (int y = 0; y < sizeInChunks.y; y++)
			{
				for (int x = 0; x < sizeInChunks.z; x++)
				{
					GameObject newChunkGo = new GameObject("Chunk");
					newChunkGo.transform.parent = this.transform;
					newChunkGo.transform.localPosition = new Vector3(x*16f, y*16f, z*16f);
					ChunkUI chunkUI = newChunkGo.AddComponent<ChunkUI>();
					Chunk newChunk = new Chunk(new Vector3((float)x, (float)y, (float)z));
					chunkUI.chunk = newChunk;
					//if bottom chunk build floor
					if (y == 0) newChunk.BuildFlatFloor();



					chunks.Add(newChunk);
					chunkUI.UpdatePieces();

				}
			}
		}
	}





	public IEnumerator LoadWorld()
	{
		Task<IEnumerable<ParseObject>> task = ParseObject.GetQuery("Chunks").FindAsync();
		
		while (!task.IsCompleted) yield return new WaitForEndOfFrame();
		
		if (task.IsFaulted) Debug.LogError(task.Exception.Message);
		else
		{
			List<ParseObject> loadedChunks = new List<ParseObject>(task.Result);
			Debug.Log(loadedChunks.Count);
		}
	}


}
