using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	GameObject n, d, o, m, myObj;

	private float pos_y = 10;

	void Start () {
		n = GameObject.Find ("omura");
		d = GameObject.Find ("douya");
		o = GameObject.Find ("ohata");
		m = GameObject.Find ("miura");
		myObj = n.GetComponent<Contoroller> ().isMine ? n.gameObject:
			d.GetComponent<Contoroller> ().isMine ? n.gameObject:
			o.GetComponent<Contoroller> ().isMine ? n.gameObject:
			m.GetComponent<Contoroller> ().isMine ? n.gameObject:null;
	}
	
	void Update () {
		if (myObj) {
			transform.position = new Vector3 (myObj.transform.position.x, pos_y, myObj.transform.position.z);
		}
	}
}
