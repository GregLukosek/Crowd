using UnityEngine;
using System.Collections;

public class ChunkUI : MonoBehaviour
{

	public Chunk chunk;


	void OnDisable()
	{
		chunk.OnChunksUpdate -= UpdatePieces;
	}


	public void Set(Chunk chunk_)
	{
		chunk = chunk;
		chunk.OnChunksUpdate += UpdatePieces;
		UpdatePieces();
	}


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
				PieceUI pieceUI = pieceGO.GetComponent<PieceUI>();
				pieceUI.Set(piece, piece.x, piece.y, piece.z);

			}
		}
	}



}
