using UnityEngine;



public class network:MonoBehaviour{

	// Use this for initialization
	void Start () {
		Debug.Log ("KING");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void connectNow() {

		}
	
	public network() {



	}


	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

}
