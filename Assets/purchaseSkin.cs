﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

// Script que se ejecuta al realizar una compra en la tienda
public class purchaseSkin : MonoBehaviour {
	public int item;
	int redUnlocked, blueUnlocked, purpleUnlocked, goldUnlocked, gems, selectedItem;
	
	// Fijamos el precio de cada item con las siguientes constantes:
	const int RED_PRICE = 50;
	const int BLUE_PRICE = 15;
	const int GOLD_PRICE = 500;
	const int PURPLE_PRICE = 100;

	Rect windowRect;

	string getPrevItem(){
		string result = "";
		
		// Obtenemos el codigo asociado a cada item
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

	// Al hacer click en el boton si se cumplen las condiciones se compra el objeto
	// y se vuelve a cargar la escena con el objeto seleccionado.
	// Se desbloquean logros por realizar la compra.
	public void onClick(){
		gems = PlayerPrefs.GetInt ("gems");

		redUnlocked = PlayerPrefs.GetInt ("redUnlocked");
		blueUnlocked = PlayerPrefs.GetInt ("blueUnlocked");
		purpleUnlocked = PlayerPrefs.GetInt ("purpleUnlocked");
		goldUnlocked = PlayerPrefs.GetInt ("goldUnlocked");
		selectedItem = PlayerPrefs.GetInt ("selectedItem");

		switch (item) {
		case 0:

			GameObject.Find (getPrevItem ()).GetComponent<Image> ().color = Color.white;
			GameObject.Find ("GreenDroidButton").GetComponent<Image> ().color = Color.blue;

			selectedItem = 0;
			PlayerPrefs.SetInt("selectedItem",selectedItem);

			break;
		case 1:
			if (redUnlocked == 0 && gems >= RED_PRICE) {
				gems -= RED_PRICE;
				PlayerPrefs.SetInt("gems",gems);
				PlayerPrefs.SetInt("redUnlocked",1);
				GameObject.Find ("myGems").GetComponentInChildren<Text> ().text = gems+"";
				Social.ReportProgress("CgkIh-a8y9sQEAIQAw", 100.0f, (bool success) => {});
				Application.LoadLevel(2);
			}
			else if (redUnlocked == 1){

				GameObject.Find (getPrevItem ()).GetComponent<Image> ().color = Color.white;
				GameObject.Find ("RedDroidButton").GetComponent<Image> ().color = Color.blue;

				selectedItem = 1;
				PlayerPrefs.SetInt("selectedItem",selectedItem);
			}
			break;
		case 2:
			if (goldUnlocked == 0 && gems >= GOLD_PRICE) {
				gems -= GOLD_PRICE;
				PlayerPrefs.SetInt("gems",gems);
				PlayerPrefs.SetInt("goldUnlocked",1);
				GameObject.Find ("myGems").GetComponentInChildren<Text> ().text = gems+"";
				Social.ReportProgress("CgkIh-a8y9sQEAIQBQ", 100.0f, (bool success) => {});
				Application.LoadLevel(2);
			}
			else if (goldUnlocked == 1){

				GameObject.Find (getPrevItem ()).GetComponent<Image> ().color = Color.white;
				GameObject.Find ("GoldDroidButton").GetComponent<Image> ().color = Color.blue;

				selectedItem = 2;
				PlayerPrefs.SetInt("selectedItem",selectedItem);
			}
			break;
		case 3:
			if (purpleUnlocked == 0 && gems >= PURPLE_PRICE) {
				gems -= PURPLE_PRICE;
				PlayerPrefs.SetInt("gems",gems);
				PlayerPrefs.SetInt("purpleUnlocked",1);
				GameObject.Find ("myGems").GetComponentInChildren<Text> ().text = gems+"";
				Social.ReportProgress("CgkIh-a8y9sQEAIQBA", 100.0f, (bool success) => {});
				Application.LoadLevel(2);
			}
			else if (purpleUnlocked == 1){

				GameObject.Find (getPrevItem ()).GetComponent<Image> ().color = Color.white;
				GameObject.Find ("PurpleDroidButton").GetComponent<Image> ().color = Color.blue;

				selectedItem = 3;
				PlayerPrefs.SetInt("selectedItem",selectedItem);
			}
			break;
		case 4:
			if (blueUnlocked == 0 && gems >= BLUE_PRICE) {
				gems -= BLUE_PRICE;
				PlayerPrefs.SetInt("gems",gems);
				PlayerPrefs.SetInt("blueUnlocked",1);
				GameObject.Find ("myGems").GetComponentInChildren<Text> ().text = gems+"";
				Social.ReportProgress("CgkIh-a8y9sQEAIQAg", 100.0f, (bool success) => {});
				Application.LoadLevel(2);
			}
			else if (blueUnlocked == 1){

				GameObject.Find (getPrevItem ()).GetComponent<Image> ().color = Color.white;
				GameObject.Find ("BlueDroidButton").GetComponent<Image> ().color = Color.blue;

				selectedItem = 4;
				PlayerPrefs.SetInt("selectedItem",selectedItem);
			}
			break;
		}
	}
}