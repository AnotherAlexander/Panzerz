using UnityEngine;
using System.Collections;

public class mainmenu {

	// Use this for initialization
	void Start () {

	}

	public  mainmenu() {
		ui mainMenu = new ui ();
		mainMenu.makeButton ("MAIN MENU", 20, 5, 60, 10);


		if (mainMenu.makeButton ("EXIT GAME", 40, 60, 30, 10)) {
			Application.Quit();
				}
	}
	
	// Update is called once per frame
	void Update () {
	
	}




}
