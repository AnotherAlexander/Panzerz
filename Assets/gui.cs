﻿using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.1");

	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnJoinedLobby(){

	}

	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Can't join random room!");
		PhotonNetwork.CreateRoom(null);
	}

	void joinRoom() {
		PhotonNetwork.JoinRandomRoom();
		}
	
	void OnGUI() {
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		if (!PhotonNetwork.inRoom) {

						if (GUI.Button (new Rect (10, 10, 150, 100), "Play!")) {
								joinRoom ();		
						}
				}
			print("You clicked the button!");









	

	}



}