using UnityEngine;
using System.Collections;

public class UniverseScript : MonoBehaviour {
	GameObject Bar;
	GameObject Player;
	GameObject Background;

	// Use this for initialization
	void Start () {
		Bar = GameObject.Find ("DriveBar");
		Player = GameObject.FindGameObjectWithTag ("Player");
		Background = GameObject.FindGameObjectWithTag ("Background");
		Bar.GetComponent< GUIBarScript > ().ScaleSize = 0;
		Bar.GetComponent< GUIBarScript > ().DisplayText = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
