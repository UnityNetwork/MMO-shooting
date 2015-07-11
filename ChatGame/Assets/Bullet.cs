using UnityEngine;
using System.Collections;

public class Bullet : Mover {

	int count = 0;
	Vector3 vec;
	public void Init (GameObject g, Vector3 v) {
		owner = g;
		vec = v;
	}

	void Start () {
	
	}
	
	void Update () {
		transform.position += vec;

		count++;
		if (count > 120) {
			Destroy (gameObject);
		}
		GetComponent <NetworkView> ().RPC ("MovePlayer", RPCMode.Others, transform.position);
	}

	[RPC]
	public void MovePlayer (Vector3 position) {
		transform.position = position;
	}
}
