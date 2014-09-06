using UnityEngine;
using System.Collections;


public class Chunk
{
	public Vector3 worldIndex = new Vector3();
	public Piece[,,] pieces = new Piece[16,16,16];



	public Chunk(Vector3 _worldIndex)
	{
		worldIndex = _worldIndex;
		pieces = new Piece[16,16,16];
	}


	public void AddPiece(int _x, int _y, int _z)
	{
		pieces[_x, _y, _z] = new Piece(_x, _y, _z);
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



}
