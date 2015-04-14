using UnityEngine;
using System.Collections;

public class menuButtonScript : MonoBehaviour {

	GameObject bg_music;

	public void Start(){
		bg_music = GameObject.Find ("bg_music");
	}
	
	public void onClick(){
		Debug.Log ("Menu");
		Time.timeScale = 1;
		bg_music.GetComponent<AudioSource> ().Stop ();
		Application.LoadLevel (0);
	}
}

