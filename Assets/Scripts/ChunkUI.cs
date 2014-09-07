using UnityEngine;
using System.Collections;

public class ChunkUI : MonoBehaviour
{
	public Chunk chunk;

	public void UpdatePieces()
	{
		foreach (Piece piece in chunk.pieces)
		{
			if (piece != null) 
			{
				//create cube here
				GameObject pieceGO = (GameObject)Instantiate(World.instance.piecePrefab);
				pieceGO.transform.parent = this.transform;
				pieceGO.transform.localPosition = new Vector3(piece.x, piece.y, piece.z);



			}
		}
	}



}
