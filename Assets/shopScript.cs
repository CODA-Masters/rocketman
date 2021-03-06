﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Script que usa la escena de la tienda
public class shopScript : MonoBehaviour {

	int gems, redUnlocked, blueUnlocked, purpleUnlocked, goldUnlocked, selectedItem;

	// Obtenemos el item a partir del codigo asociado
	string getPrevItem(){
		string result = "";
		
		switch (selectedItem) {
		case 0:
			result = "GreenDroidButton";
			break;
		case 1:
			result = "RedDroidButton";
			break;
		case 2:
			result = "GoldDroidButton";
			break;
		case 3:
			result = "PurpleDroidButton";
			break;
		case 4:
			result = "BlueDroidButton";
			break;
		}
		
		return result;
	}

	// Al iniciar la escena comprobamos que esta desbloqueado y que elemento tenemos seleccionado
	void Start () {

		redUnlocked = PlayerPrefs.GetInt ("redUnlocked");
		blueUnlocked = PlayerPrefs.GetInt ("blueUnlocked");
		purpleUnlocked = PlayerPrefs.GetInt ("purpleUnlocked");
		goldUnlocked = PlayerPrefs.GetInt ("goldUnlocked");
		selectedItem = PlayerPrefs.GetInt ("selectedItem");

		gems = PlayerPrefs.GetInt ("gems");
		GameObject.Find ("myGems").GetComponentInChildren<Text> ().text = gems+"";
		GameObject.Find (getPrevItem ()).GetComponent<Image> ().color = Color.blue;

		if (redUnlocked == 1) {
			Vector3 pos = GameObject.Find ("RedDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().rectTransform.position;
			pos.x = GameObject.Find ("RedDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Image> ().rectTransform.position.x * 1.14f;

			GameObject.Find ("RedDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().rectTransform.position = pos;
			GameObject.Find ("RedDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Image> ().rectTransform.localScale = new Vector3 (0, 0, 0);
			GameObject.Find ("RedDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().text = "UNLOCKED";
			GameObject.Find ("RedDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().fontSize = 40;
			GameObject.Find ("RedDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().color = Color.red;
		}

		if (blueUnlocked == 1) {
			Vector3 pos = GameObject.Find ("BlueDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().rectTransform.position;
			pos.x = GameObject.Find ("BlueDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Image> ().rectTransform.position.x * 1.75f;
			
			GameObject.Find ("BlueDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().rectTransform.position = pos;
			GameObject.Find ("BlueDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Image> ().rectTransform.localScale = new Vector3 (0, 0, 0);
			GameObject.Find ("BlueDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().text = "UNLOCKED";
			GameObject.Find ("BlueDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().fontSize = 40;
			GameObject.Find ("BlueDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().color = Color.blue;
		}

		if (purpleUnlocked == 1) {
			Vector3 pos = GameObject.Find ("PurpleDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().rectTransform.position;
			pos.x = GameObject.Find ("PurpleDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Image> ().rectTransform.position.x * 1.14f;
			
			GameObject.Find ("PurpleDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().rectTransform.position = pos;
			GameObject.Find ("PurpleDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Image> ().rectTransform.localScale = new Vector3 (0, 0, 0);
			GameObject.Find ("PurpleDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().text = "UNLOCKED";
			GameObject.Find ("PurpleDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().fontSize = 40;
			GameObject.Find ("PurpleDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().color = Color.magenta;
		}

		if (goldUnlocked == 1) {
			Vector3 pos = GameObject.Find ("GoldDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().rectTransform.position;
			pos.x = GameObject.Find ("GoldDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Image> ().rectTransform.position.x * 1.08f;
			
			GameObject.Find ("GoldDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().rectTransform.position = pos;
			GameObject.Find ("GoldDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Image> ().rectTransform.localScale = new Vector3 (0, 0, 0);
			GameObject.Find ("GoldDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().text = "UNLOCKED";
			GameObject.Find ("GoldDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().fontSize = 40;
			GameObject.Find ("GoldDroidButton").transform.FindChild ("Gem").GetComponentInChildren<Text> ().color = Color.yellow;
		}


	}
	
	// Update is called once per frame
	void Update () {

	}
}
