using UnityEngine;
using UnityEditor;
using System.Collections;


[CustomEditor(typeof(PhotonManager))]

public class PhotonManagerEditor : Editor
{

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();



		//rooms list
		string roomsList = "";

		foreach (RoomInfo roomInfo in PhotonNetwork.GetRoomList()) roomsList += roomInfo.ToString();


		if (Application.isPlaying && PhotonNetwork.connected)
		{
			EditorGUILayout.TextField("Lobby: " + PhotonNetwork.lobby.Type, new GUILayoutOption[]{});


			if (PhotonNetwork.lobby != null)
			{
				EditorGUILayout.TextField("Rooms in the lobby: " + PhotonNetwork.countOfRooms , new GUILayoutOption[]{});
			}


			if (PhotonNetwork.room != null)
			{
				EditorGUILayout.TextField("Room player count: " + PhotonNetwork.room.playerCount , new GUILayoutOption[]{});
			}


		}


		Repaint();
	}
}
