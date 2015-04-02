using UnityEngine;
using System.Collections;

public class UniverseScript : MonoBehaviour {
	GameObject Bar;
	GameObject RetryButton;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		Bar = GameObject.Find ("DriveBar");
		RetryButton = GameObject.Find ("RetryButton");
		Bar.GetComponent< GUIBarScript > ().ScaleSize = 0;
		Bar.GetComponent< GUIBarScript > ().DisplayText = false;
		RetryButton.GetComponent<RectTransform> ().localScale = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
