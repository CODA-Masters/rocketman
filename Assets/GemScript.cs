using UnityEngine;
using System.Collections;

// Script que usan las gemas
public class GemScript : MonoBehaviour {

	GameObject universe;
	
	void Start(){
		universe = GameObject.Find ("Universe");
	}

	/*Cuando la gema colisiona con el jugador se añade la gema al contador,
	desaparece y suena el sonido de recogerla */
	void OnTriggerEnter2D(Collider2D collider){
		universe.GetComponent<UniverseScript>().addGem();
		transform.localScale = new Vector3 (0, 0, 0);
		GameObject.Find ("Pickup_Gem").GetComponent<AudioSource> ().Play ();
	}
	
}
