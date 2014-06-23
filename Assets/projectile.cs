using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class projectile : Photon.MonoBehaviour {
	private PhotonView myPhotonView;
	private int damage;

	// Use this for initialization
	void Start () {
		if (photonView.isMine) {
			damage = ingame.damagePerShot;
			rigidbody.AddForce(transform.forward*10000);
		} else {
			rigidbody.isKinematic = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			// We own this player: send the others our data
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		}
		else
		{
			// Network player, receive data
			this.transform.position = (Vector3) stream.ReceiveNext();
			this.transform.rotation = (Quaternion) stream.ReceiveNext();
		}
	} 

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "enemy") {
		
			collision.gameObject.SendMessage("applyDamage");

		}	
		PhotonNetwork.Destroy(gameObject);
	}
}