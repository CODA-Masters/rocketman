using UnityEngine;
using System.Collections;

// Script que usa el boton de menu
public class menuButtonScript : MonoBehaviour {

	GameObject bg_music;

	public void Start(){
		bg_music = GameObject.Find ("bg_music");
	}
	
	/* Al pinchar sobre el boton paramos la musica del juego y
	cargamos la escena del menu */
	public void onClick(){
		Debug.Log ("Menu");
		Time.timeScale = 1;
		bg_music.GetComponent<AudioSource> ().Stop ();
		Application.LoadLevel (0);
	}
}

