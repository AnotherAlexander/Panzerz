using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ingame:Photon.MonoBehaviour {

	public static bool alive = false;
	public static float deathCounter;
	public static float deathCounterValue = 1.0F;
	private int deathInt;
	public static int damagePerShot = 10;
	public GUISkin mySkin;
	private GameObject theTank;

	List<string> chatList = new List<string>();

	// Use this for initialization
	void Start () {
		Debug.Log ("INGAME-Object instantiated");
		deathCounter = deathCounterValue;
		


	}
	
	// Update is called once per frame
	void Update () {
		if(!alive && deathCounter > 0.0F) {
			deathCounter -= Time.deltaTime;
		}
		if (deathCounter < 0) {
			deathCounter = 0;
		}
	}

	void OnGUI() {
		GUI.skin = mySkin;
		ui newUI = new ui();




	
			if (!alive) {

								if (deathCounter != 0.0F && !alive) {
										deathInt = (int)deathCounter;
										newUI.makeLabel (deathInt.ToString (), 80, 0, 20, 5);
								} else if (deathCounter == 0.0F && !alive) {
										if (newUI.makeButton ("Spawn", 75, 5, 20, 5)) {
					if(theTank != null) {PhotonNetwork.Destroy(theTank); }
					 theTank = PhotonNetwork.Instantiate ("Panzer", new Vector3(0,2,0), Quaternion.identity, 0) as GameObject;
					alive = true;
										}
								}
						}
		}
}
