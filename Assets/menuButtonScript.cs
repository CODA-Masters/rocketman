using UnityEngine;
using System.Collections;

public class menuButtonScript : MonoBehaviour {
	
	public void onClick(){
		Debug.Log ("Menu");
		Time.timeScale = 1;
		Application.LoadLevel (0);
	}
}

