using UnityEngine;
using System.Collections;


public class Chunk
{
	public delegate void OnChunksUpdateHandler();
	public event OnChunksUpdateHandler OnChunksUpdate;


	public Vector3 worldIndex = new Vector3();
	public Piece[,,] pieces = new Piece[16,16,16];


	public Chunk(Vector3 _worldIndex)
	{
		worldIndex = _worldIndex;
		pieces = new Piece[16,16,16];


	}


	public void BuildFlatFloor()
	{
		//creating floor
		// Loop over each dimension's length.
		for (int z = 0; z < 16; z++)
		{
			for (int x = 0; x < 16; x++)
			{
				AddPiece(x,0,z);
			}
		}
	}



	public void AddPiece(int _x, int _y, int _z)
	{
		pieces[_x, _y, _z] = new Piece(this, _x, _y, _z);
		if (OnChunksUpdate != null) OnChunksUpdate();
	}




	public string Serialize()
	{
		string result = "";

		foreach (Piece piece in pieces)
		{
			if (piece != null) result += "["+piece.x+","+piece.y+","+piece.z+"]";
		}
		return result;
	}



	public int PiecesCount()
	{
		int result = 0;
		foreach (Piece piece in pieces)
		{
			if (piece != null) result++;
		}
		return result;
	}

}




