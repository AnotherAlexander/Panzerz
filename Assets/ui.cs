using UnityEngine;
using System.Collections;

public class ui{

	// Use this for initialization
	void Start () {

	}

	public ui() {


	}


	public static string testInt="hello world";

	public bool makeButton(string theString, float posX, float posY, float lengthX, float lengthY) {
		GUI.depth = 1;

		if (GUI.Button (new Rect (Screen.width/100.0F*posX, Screen.height/100.0F*posY, Screen.width/100.0F*lengthX, Screen.height/100.0F*lengthY), theString)) {
			return true;
		} else {
			return false;
		}

	}

	public bool makeLabel(string theString, float posX, float posY, float lengthX, float lengthY) {
		GUI.depth = 1;
		GUI.Label (new Rect (Screen.width / 100.0F * posX, Screen.height / 100.0F * posY, Screen.width / 100.0F * lengthX, Screen.height / 100.0F * lengthY), theString);

		return true;
	}

	public bool makeImage(Texture theTexture, float posX, float posY, float lengthX, float lengthY) {
		GUI.depth = 0;
		GUI.DrawTexture (new Rect (Screen.width / 100.0F * posX, Screen.height / 100.0F * posY, Screen.width / 100.0F * lengthX, Screen.height / 100.0F * lengthY), theTexture, ScaleMode.ScaleAndCrop, true, 1.0F);
		return true;
	}

	public bool loadingScreen() {
		GUI.depth = 0;
		GUI.Label (new Rect (Screen.width / 100.0F * 35, Screen.height / 100.0F * 35, Screen.width / 100.0F * 30, Screen.height / 100.0F * 30), "LOADING");
		return true;
	}






	// Update is called once per frame
	void Update () {
	
	}
}
