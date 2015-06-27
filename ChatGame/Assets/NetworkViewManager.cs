using UnityEngine;
using System.Collections;

public class NetworkViewManager : MonoBehaviour {

	public static bool connected = false;

	private string connectionIP = "10.25.32.252";
	private int portNumber = 8080;

	void OnGUI () {
		GUILayout.Label ("接続人数" + Network.connections.Length.ToString ());
		if (connected) {
			if (GUILayout.Button ("Disconnect")) {
				Network.Disconnect ();
			}
		} else {
			if (GUILayout.Button ("Connect")) {
				Network.Connect (connectionIP, portNumber);
			}
			if (GUILayout.Button ("Server")) {
				Network.InitializeServer (20, portNumber);
			}
		}
	}

	void OnPlayerConnected (NetworkPlayer player) {
		connected = true;
	}

	void OnServerInitialized () {
		connected = true;
	}

	void OnConnectedToServer () {
		connected = true;
	}

	void OnDisconnectedFromServer (NetworkDisconnection info) {
		connected = false;
	}
}
