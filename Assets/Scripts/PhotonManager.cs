using UnityEngine;
using System.Collections;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System;


public class PhotonManager : Photon.MonoBehaviour
{
	public static PhotonManager instance;
	public PhotonLogLevel logLevel;

	public string version = "0.1";




	void Awake()
	{
		instance = this;
		Connect();
	}


	public void Connect()
	{
		PhotonNetwork.ConnectToBestCloudServer(version);
		PhotonNetwork.autoJoinLobby = true;
		PhotonNetwork.OnEventCall += OnEventCall;
		PhotonNetwork.logLevel = logLevel;

	}


	#region events

	//Called if server is recheable
	public void OnConnectedToPhoton()
	{
		Debug.Log("OnConnectedToPhoton");
	}

	//Called if server is unrechable
	public void OnFailedToConnectToPhoton()
	{
		Debug.LogError("OnFailedToConnectToPhoton");
	}
	

	public virtual void OnConnectedToMaster()
	{
		if (PhotonNetwork.networkingPeer.AvailableRegions != null) Debug.LogWarning("List of available regions counts " + PhotonNetwork.networkingPeer.AvailableRegions.Count + ". First: " + PhotonNetwork.networkingPeer.AvailableRegions[0] + " \t Current Region: " + PhotonNetwork.networkingPeer.CloudRegion);
		Debug.Log("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinRandomRoom();");
	}


	public virtual void OnJoinedLobby()
	{
		Debug.Log("OnJoinedLobby()");


		RoomOptions options = new RoomOptions();
		options.maxPlayers = 0;
		options.isOpen = true;
		options.isVisible = true;
		
		//check is there is a MainRoom already if not create
		PhotonNetwork.JoinOrCreateRoom("mainroom", options, TypedLobby.Default);
	}




	public void OnJoinedRoom()
	{
		Debug.Log("Joined room");
		PhotonNetwork.Instantiate("userprefab", Vector3.zero, Quaternion.identity, 0);

	}


	public void OnPhotonRandomJoinFailed() 
	{ 
		Debug.Log("Random Join failed, creating room");
		// codeAndMsg[0] is int ErrorCode. codeAndMsg[1] is string debug msg. 
	}



	void OnEventCall(byte eventCode, object content, int senderId)
	{
		Debug.Log("event received: sender id" + senderId.ToString());
	}



	#endregion

	



	#region GUI

	void OnGUI()
	{

		if (PhotonNetwork.room != null)
		{
			Room room = PhotonNetwork.room;

			GUILayout.Label("Room info: " , new GUILayoutOption[]{});
			GUILayout.Label("name: " + room.name, new GUILayoutOption[]{});
			GUILayout.Label("players: " + room.playerCount , new GUILayoutOption[]{});
		}

	}





	#endregion



}







