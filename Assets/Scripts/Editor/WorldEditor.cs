using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(World))]
public class WorldEditor : Editor 
{

	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector();

		if (Application.isPlaying)
		{
			GUILayout.TextArea("Chunks count: " + World.instance.chunks.Count);

			int piecesCount = 0;
			foreach (Chunk chunk in World.instance.chunks) piecesCount += chunk.PiecesCount();
			GUILayout.TextArea("Pieces count: " + piecesCount);
		}

			              
		Repaint();


	}
}
