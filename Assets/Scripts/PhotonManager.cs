using UnityEngine;
using System.Collections;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System;
using System.Collections.Generic;


public class PhotonManager : Photon.MonoBehaviour
{
	public static PhotonManager instance;
	public PhotonLogLevel logLevel;

	public string version = "0.1";




	void Awake()
	{
		instance = this;
//		Connect();
	}


	public void Connect()
	{
		PhotonNetwork.ConnectUsingSettings(version);
		PhotonNetwork.autoJoinLobby = true;
		PhotonNetwork.OnEventCall += OnEventCall;
		PhotonNetwork.logLevel = logLevel;

	}


	#region events

	//Called if server is recheable
	public void OnConnectedToPhoton()
	{
		Debug.Log("OnConnectedToPhoton");

		Hashtable properties = new Hashtable();
		properties.Add("fbid", FB.UserId);


		PhotonNetwork.player.SetCustomProperties(properties);
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


//
//	PhotonPlayer[] playersInRoom = new PhotonPlayer[1];



	public void OnJoinedRoom()
	{
		Debug.Log("Joined room");
		GameObject userPrefab = PhotonNetwork.Instantiate("userprefab", new Vector3(10f,5f,10f), Quaternion.identity, 0);


//		foreach (PhotonPlayer player in PhotonNetwork.playerList)
//		{
//			Debug.Log("new player fb id: " + (string)player.customProperties["fbid"]);
//			
//		}
//		
//		playersInRoom = PhotonNetwork.playerList;


	}


	public void OnPhotonRandomJoinFailed() 
	{ 
		Debug.Log("Random Join failed, creating room");
		// codeAndMsg[0] is int ErrorCode. codeAndMsg[1] is string debug msg. 
	}


	public void OnPhotonPlayerConnected(PhotonPlayer newPlayer) 
	{

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







