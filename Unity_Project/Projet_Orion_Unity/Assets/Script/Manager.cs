using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
	#region Public_Variable
	
	//public string Body;
	public string Snake;
	public bool OnlineGame;
	
	#endregion

	
	#region Private_Variable
	
	private GameObject Snake_object;

	#endregion
	

	// Use this for initialization
	void Start ()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
		PhotonNetwork.offlineMode = !OnlineGame;
		if (!OnlineGame)
		{
			PhotonNetwork.CreateRoom("room");
//			Snake_object = PhotonNetwork.Instantiate(Snake, Vector3.up, Quaternion.Euler(0,0,0), 0);
//			Snake_object.GetComponent<Snake_Mouvement>().enabled = true;
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetKeyDown(KeyCode.Escape))
			SceneManager.LoadScene(0);
	}
	
	//Fonction called when player join a seveur
	void OnJoinedLobby()
	{
		
		Debug.Log("Joined Lobby");
		PhotonNetwork.JoinRandomRoom();
     }

	//Fonction called when there is no create room
	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Joined Failed");
		PhotonNetwork.CreateRoom("room");
	}

	//Fonction called when the player join a party
	void OnJoinedRoom()
	{
		Debug.Log("Joined");
		Snake_object = PhotonNetwork.Instantiate(Snake, Vector3.up, Quaternion.Euler(0,0,0), 0);
		Snake_object.GetComponent<snake_mouvement>().enabled = true;
//		Snake_object.SetActive(false);
//		Snake_object.SetActive(true);
//		Transform Camera = PhotonNetwork.Instantiate("Camera", Snake_object.transform.position, Snake_object.transform.rotation, 0).transform;
//		Camera.SetParent(Snake_object.transform);
		//Snake_object..enabled = true;
		//Snake_player Head = new Snake_player();
		//PhotonNetwork.Instantiate("Head", Vector3.zero, Quaternion.identity, 0);
	}
	
	
	
	public void mouvement_body()
	{
		/*for (int i = 0; i < Head.Bodys.Count; i++)
		{
			Head.Bodys[i].mouvement(Head);
			/*if (Head.Bodys[i].transform.position == Head.ChangePos)
				Head.Temp_Dir = Head.Direction;
			Head.Bodys[i].transform.Translate(Head.Temp_Dir * Time.deltaTime * Head.Speed);
		}*/
	}

}
