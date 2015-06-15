using UnityEngine;
using System.Collections;

// Este script lo usa la camara para seguir al jugador cuando se mueve
public class CameraTracksPlayer : MonoBehaviour {

	Transform player;

	float offsetX;

	// Use this for initialization
	void Start () {

		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");

		if (player_go == null) {
			Debug.LogError("Couldn't find an object with tag 'Player'");
			return;
		}
	

		player = player_go.transform;

		offsetX = transform.position.x - player.position.x;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			// La camara se situa en una posicion relativa al jugador
			Vector3 pos = transform.position;
			pos.x = player.position.x + offsetX;
			transform.position = pos;
		}
	}
}
