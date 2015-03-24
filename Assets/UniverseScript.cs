using UnityEngine;
using System.Collections;

public class UniverseScript : MonoBehaviour {
	public GameObject Bar;

	// Use this for initialization
	void Start () {
		Bar = GameObject.Find ("DriveBar");
		Bar.GetComponent< GUIBarScript > ().ScaleSize = 0;
		Bar.GetComponent< GUIBarScript > ().DisplayText = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
