using UnityEngine;
using System.Collections;

public class startButtonScript : MonoBehaviour {

	public void onClick(){
		Debug.Log ("Start");
		Application.LoadLevel ("main");
	}
}
