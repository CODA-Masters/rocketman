using UnityEngine;
using System.Collections;

public class tragabicho : MonoBehaviour {

	GameObject Player;
	bool contact = false;
	
	void Start(){
		Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		contact = true;
		Player.GetComponent<Rigidbody2D>().gravityScale = 0;
		Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
	}
	
	void Update(){

	}
}
