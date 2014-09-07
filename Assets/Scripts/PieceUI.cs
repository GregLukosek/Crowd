using UnityEngine;
using System.Collections;

public class PieceUI : MonoBehaviour 
{
	public Piece piece;

	public int x;
	public int y;
	public int z;

	public void Set(Piece piece_, int _x, int _y, int _z)
	{
		piece = piece_;
		x = _x;
		y = _y;
		z = _z;

	}
}
