using UnityEngine;
using System.Collections;

public class UniverseScript : MonoBehaviour {
	GameObject Bar;
	GameObject RetryButton;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		Bar = GameObject.Find ("PowerBar");
		RetryButton = GameObject.Find ("RetryButton");
		//Bar.GetComponent< RectTransform > ().localScale = new Vector3 (0, 0, 0);
		RetryButton.GetComponent<RectTransform> ().localScale = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
