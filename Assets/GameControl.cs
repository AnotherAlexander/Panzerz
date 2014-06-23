using UnityEngine;
using System.Collections;



public class GameControl  : MonoBehaviour {

	public GameObject inGame;
	private bool mainMenu = true;
	private bool mainMenuContextMenu = false;

	private bool isJoining = false;

	public Texture backgroundImage;
	public GUISkin mySkin;

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.1");

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && !mainMenuContextMenu) {
			mainMenuContextMenu = true;
		} else if(Input.GetKeyDown (KeyCode.Escape) && mainMenuContextMenu) {
			mainMenuContextMenu = false;
		}
	}



	void OnGUI() {
		GUI.skin = mySkin;
		ui newUI = new ui();

	


		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());

		if (mainMenu) {
			newUI.makeImage (backgroundImage, 0, 0, 100, 100);
			if(!isJoining) {
				if (newUI.makeButton ("Play Now!", 40.0F, 20.0F, 20.0F, 10.0F)) {
					isJoining = true;
					PhotonNetwork.JoinRandomRoom ();
				}
			} else {
				newUI.loadingScreen();
			}


		}

		
		if (mainMenuContextMenu) {
			if (newUI.makeButton ("EXIT", 40.0F, 10.0F, 20.0F, 10.0F)) {
				Application.Quit();
			}
		}


	}

	void OnPhotonRandomJoinFailed()
	{
		PhotonNetwork.CreateRoom(null);
	}
	
	void OnJoinedLobby() {
		
	}

	void OnJoinedRoom() {
		isJoining = false;
		Debug.Log ("JOINED ROOM");

		Instantiate (inGame, Vector3.zero, Quaternion.identity);

		mainMenu = false;
	}
	
	
}
