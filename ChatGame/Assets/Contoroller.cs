using UnityEngine;
using System.Collections;

public class Contoroller : Mover {

	public bool isMine;
	float s = 0.5f;

	GameObject bullet;
	void Start () {
		bullet = (GameObject)Resources.Load ("Bullet");
	}

	void Update () {
		if (!NetworkViewManager.connected) {
			return;
		}

		if (isMine) {
			Vector3 v = new Vector3 (Input.GetAxis ("Horizontal"), 0 ,Input.GetAxis ("Vertical"));
			transform.Translate (v*Time.deltaTime*10f);
			if (Input.GetKeyDown (KeyCode.Space)) {
				int rad = 360 / 10;
				for(int i = 0; i < 360; i += rad){
					Vector3 vel = new Vector3(Mathf.Cos(Radians(i)),0, Mathf.Sin(Radians(i))) * 0.2f;
					GameObject b = (GameObject)Network.Instantiate (bullet, transform.position, bullet.transform.rotation, 1);
					b.GetComponent<Bullet> ().Init (vel);
				}
			}
			GetComponent <NetworkView> ().RPC ("MovePlayer", RPCMode.Others, transform.position);
		}
	}

	[RPC]
	public void MovePlayer (Vector3 position) {
		transform.position = position;
	}
}
