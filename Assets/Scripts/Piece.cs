using UnityEngine;
using System.Collections;

public class Piece
{
	public Chunk chunk;

	public int x;
	public int y;
	public int z;

	public Piece(Chunk chunk_, int _x, int _y, int _z)
	{
		chunk = chunk_;
		x = _x;
		y = _y;
		z = _z;
	}

}
