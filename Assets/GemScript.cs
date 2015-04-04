using UnityEngine;
using System.Collections;

public class GemScript : MonoBehaviour {

	GameObject universe;
	
	void Start(){
		universe = GameObject.Find ("Universe");
	}

	void OnTriggerEnter2D(Collider2D collider){
		universe.GetComponent<UniverseScript>().addGem();
		transform.localScale = new Vector3 (0, 0, 0);
	}
	
}
