using UnityEngine;
using System.Collections;

// Script de boton de inicio
public class startButtonScript : MonoBehaviour {

	public void onClick(){
		// Carga el nivel del juego
		Debug.Log ("Start");
		Application.LoadLevel ("main");
	}
}
