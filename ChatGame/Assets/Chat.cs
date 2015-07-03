using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chat : MonoBehaviour {

	private List<string> messages = new List<string> ();
	private string inputMessage = "";
	private string name = "your name";

	void OnGUI () {

		if (!NetworkViewManager.connected) {
			return;
		}

		GUILayout.Space (50);
		GUILayout.BeginHorizontal (GUILayout.Width (Screen.width));
		inputMessage = GUILayout.TextField (inputMessage);

		if (GUILayout.Button ("Send")) {
			GetComponent <NetworkView> ().RPC ("chatMessage", RPCMode.All, name + ":" + inputMessage);
			inputMessage = "";
		}
		GUILayout.EndHorizontal ();


		if (GUILayout.Button ("Remove")) {
			messages.RemoveAt (0);
		}
		if (messages.Count > 10) {
			messages.RemoveAt (0);
		}

		messages.Reverse ();
		messages.ForEach (s => GUILayout.Label (s));
		messages.Reverse ();
	}

	[RPC]
	public void chatMessage (string msg) {
		messages.Add (msg);
	}
}
