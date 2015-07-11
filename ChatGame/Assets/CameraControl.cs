using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	public GameObject mine;
	
	private float pos_y = 10;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (mine.transform.position.x, pos_y, mine.transform.position.z);
	}
}
