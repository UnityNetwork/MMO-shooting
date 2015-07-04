using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	int count = 0;
	Vector3 vec;
	public void Init (Vector3 v) {
		vec = v;
	}

	private NetworkView view;

	void Start () {
		//view = GetComponent<NetworkView> ();
	}
	
	void Update () {
		transform.position += vec;

		//view.RPC ("MoveBullet",RPCMode.Others,transform.position);

		count++;
		if (count > 120) {
			Destroy (gameObject);
		}
	}

	/*[RPC]
	public void MovePlayer (Vector3 position) {
		transform.position = position;
    }*/
}
