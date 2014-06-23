using UnityEngine;
using System.Collections;

public class steuerung_simulator : Photon.MonoBehaviour {
	private PhotonView myPhotonView2;

	public WheelCollider linksvorne;
	public WheelCollider rechtsvorne;
	public WheelCollider linkshinten;
	public WheelCollider rechtshinten;

	public GameObject lookAt;



	public GameObject turm;
	public GameObject rohr;
	public GameObject shootFrom;

	public GameObject myCam;
	public GameObject cameraMount;

	public GameObject cameraPoint;

	public float maxSpeed=7;

	private GameObject theProjectile = null;

	private bool inverteHandles = true;
	public float acceleration = 3.0F;

	public int lifePoints = 100;


	private float shootCountdown=0;
	private float shotCountdownValue = 5.0F;

	[RPC]
	void destroyThis() {
		if (networkView.isMine) {
			if (photonView.isMine) {
				PhotonNetwork.Destroy(gameObject);
				ingame.alive = false;
				
			}
			Debug.Log("Destroyed");
		}
	}

	public void applyDamage()
	{
		photonView.RPC("destroyThis", PhotonTargets.All);


	}


	// Use this for initialization
	void Start () {
		rigidbody.centerOfMass = new Vector3 (0, -0.7F, 0);

		if (photonView.isMine) {
			shootCountdown = shotCountdownValue;
			myCam = GameObject.Find ("Main Camera");
			myCam.transform.position = cameraMount.transform.position;
			myCam.transform.parent = turm.transform;
		} else {
			rigidbody.isKinematic = true;
			this.tag = "enemy";
		}

	}
	
	// Update is called once per frame

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			// We own this player: send the others our data
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
			stream.SendNext(turm.transform.rotation);
			stream.SendNext(rohr.transform.rotation);
			stream.SendNext(lifePoints);
		}
		else
		{
			// Network player, receive data
			this.transform.position = (Vector3) stream.ReceiveNext();
			this.transform.rotation = (Quaternion) stream.ReceiveNext();
			turm.transform.rotation = (Quaternion) stream.ReceiveNext();
			rohr.transform.rotation = (Quaternion) stream.ReceiveNext();
			lifePoints = (int) stream.ReceiveNext();
		}
	}

	public bool death() {
		if (photonView.isMine) {
			ingame.alive = false;
			ingame.deathCounter = ingame.deathCounterValue;
		}
		return true;
	}

	void Update () {


		
		if (photonView.isMine) {

			myCam.transform.LookAt(lookAt.transform.position);

			//check health-status
			if(lifePoints<=0) {
				death();
			}

			//shoot

			if(shootCountdown < shotCountdownValue) {
				shootCountdown += Time.deltaTime;

			}
			if(shootCountdown > shotCountdownValue) {
				shootCountdown = shotCountdownValue;
				
			}

			if(Input.GetKeyDown(KeyCode.Space) && shootCountdown >= shotCountdownValue) {
				if(theProjectile != null) {PhotonNetwork.Destroy(theProjectile);}
				theProjectile = PhotonNetwork.Instantiate ("projectile", shootFrom.transform.position, rohr.transform.rotation, 0) as GameObject;
				shootCountdown = 0;
			}

			float currentSpeed = rigidbody.velocity.magnitude;
						if (Input.GetKey (KeyCode.LeftArrow)) {
								//turm.transform.localEulerAngles = new Vector3(0,turm.transform.localEulerAngles.y-Time.deltaTime*20,0);
								turm.transform.localEulerAngles = new Vector3 (0, turm.transform.localEulerAngles.y - Time.deltaTime * 20, 0);
						}
		
						if (Input.GetKey (KeyCode.RightArrow)) {
								turm.transform.localEulerAngles = new Vector3 (0, turm.transform.localEulerAngles.y + Time.deltaTime * 20, 0);
						}



						if (Input.GetKey (KeyCode.UpArrow)) {
								rohr.transform.Rotate (new Vector3 (turm.transform.localEulerAngles.x - Time.deltaTime * 10, 0, 0));
						}
						if (Input.GetKey (KeyCode.DownArrow)) {
								rohr.transform.Rotate (new Vector3 (turm.transform.localEulerAngles.x + Time.deltaTime * 10, 0, 0));
						}

						linksvorne.transform.localEulerAngles = new Vector3 (0, 0, 0);
						rechtsvorne.transform.localEulerAngles = new Vector3 (0, 0, 0);
						linkshinten.transform.localEulerAngles = new Vector3 (0, 0, 0);
						rechtshinten.transform.localEulerAngles = new Vector3 (0, 0, 0);

						linksvorne.motorTorque = 0;
						linkshinten.motorTorque = 0;
						rechtsvorne.motorTorque = 0;
						rechtshinten.motorTorque = 0;


						if (Input.GetKey (KeyCode.E)) {
								linksvorne.brakeTorque = 0;
								linkshinten.brakeTorque = 0;
								rechtsvorne.brakeTorque = 0;
								rechtshinten.brakeTorque = 0;
								if (inverteHandles) {
										if (currentSpeed < maxSpeed) {
												linksvorne.motorTorque = acceleration;
												linkshinten.motorTorque = acceleration;
										}
								} else {
										if (currentSpeed < maxSpeed) {
												rechtsvorne.motorTorque = acceleration;
												rechtshinten.motorTorque = acceleration;
					
										}
								}





						}


						if (Input.GetKey (KeyCode.Q)) {
								linksvorne.brakeTorque = 0;
								linkshinten.brakeTorque = 0;
								rechtsvorne.brakeTorque = 0;
								rechtshinten.brakeTorque = 0;
								if (inverteHandles) {
										if (currentSpeed < maxSpeed) {
												rechtsvorne.motorTorque = acceleration;
												rechtshinten.motorTorque = acceleration;
					
										}
								} else {
										if (currentSpeed < maxSpeed) {
												linksvorne.motorTorque = acceleration;
												linkshinten.motorTorque = acceleration;
										}
								}
			

			
			
						}



						if (Input.GetKey (KeyCode.D)) {
								linksvorne.brakeTorque = 0;
								linkshinten.brakeTorque = 0;
								rechtsvorne.brakeTorque = 0;
								rechtshinten.brakeTorque = 0;

								if (inverteHandles) {
										if (currentSpeed < maxSpeed) {
												linksvorne.motorTorque = -acceleration;
												linkshinten.motorTorque = -acceleration;
					
										}
								} else {
										if (currentSpeed < maxSpeed) {
												rechtsvorne.motorTorque = -acceleration;
												rechtshinten.motorTorque = -acceleration;
					
										}
								}
			


			
						}
		
		
						if (Input.GetKey (KeyCode.A)) {
								linksvorne.brakeTorque = 0;
								linkshinten.brakeTorque = 0;
								rechtsvorne.brakeTorque = 0;
								rechtshinten.brakeTorque = 0;

								if (inverteHandles) {
										if (currentSpeed < maxSpeed) {
												rechtsvorne.motorTorque = -acceleration;
												rechtshinten.motorTorque = -acceleration;
					
										}
								} else {
										if (currentSpeed < maxSpeed) {
												linksvorne.motorTorque = -acceleration;
												linkshinten.motorTorque = -acceleration;
					
										}
								}
			

			
			
						}

						if (!Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.Q) && !Input.GetKey (KeyCode.E)) {
			
		
								linksvorne.brakeTorque = 10;
								linkshinten.brakeTorque = 10;
								rechtsvorne.brakeTorque = 10;
								rechtshinten.brakeTorque = 10;
			
			
						}
				}

			
		} 


	void OnGUI() {

		{
		if (GUI.Button (new Rect (10, 70, 100, 40), "Invert Controls")) {
			if(inverteHandles == true) {
				inverteHandles = false;
			} else {
				inverteHandles = true;
			}
				}
			

	}
	}
}

