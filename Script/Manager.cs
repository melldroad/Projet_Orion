using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

	public GameObject Spawn;

	// Use this for initialization
	void Start ()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnJoinedLobby()
	{
		Debug.Log("Joined Lobby");
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Joined Failed");
		PhotonNetwork.CreateRoom("room");
	}

	void OnJoinedRoom()
	{
		Debug.Log("Joined");
		Instantiate(Spawn);
	}
}
