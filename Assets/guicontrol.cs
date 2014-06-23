using UnityEngine;
using System.Collections;

public class guicontrol {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	
	}


	public void initGUI() {
		if (GUI.Button(new Rect(100, 70, 50, 30), "ClickClickClickClickClickClickClick"))
			Debug.Log("Clicked the button with text");
	}


}
