using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	int count = 0;
	Vector3 vec;
	public void Init (Vector3 v) {
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
	}
}
