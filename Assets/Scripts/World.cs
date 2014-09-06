using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class World : MonoBehaviour 
{
	List<Chunk> chunks = new List<Chunk>();



	void Start()
	{
		GenerateWorld(new Vector3(4,4,4));
		chunks[0].AddPiece(3,3,3);
		chunks[0].AddPiece(4,3,3);
		chunks[0].AddPiece(5,3,3);
		Debug.Log((chunks[0].Serialize()));
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
					chunks.Add(new Chunk(new Vector3((float)x, (float)y, (float)z)));
				}
			}
		}
	}




}
