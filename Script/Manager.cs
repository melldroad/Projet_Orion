using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
	#region Public_Variable
	
	public string Body;
	public string Head;
	
	public bool OnlineGame;
	
	#endregion

	
	#region Private_Variable
	
	private GameObject head;

	#endregion
	
	
	//private Snake_player Head;

	// Use this for initialization
	void Start ()
	{
		//PhotonNetwork.Instantiate("Head", transform.position, Quaternion.identity, 0);
		PhotonNetwork.ConnectUsingSettings("0.1");
		PhotonNetwork.offlineMode = OnlineGame;
		if (OnlineGame)
		{
			//head = new Snake_player();
			head = PhotonNetwork.Instantiate(Head, transform.position, Quaternion.identity, 0);
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
		head = PhotonNetwork.Instantiate(Head, transform.position, Quaternion.identity, 0);
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
