using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Llamamos al menu de opciones desde este script
namespace FMG
{
public class optionsScript : MonoBehaviour {
	public GameObject optionsMenu, mainMenu;

	// Al pulsar el boton se realiza el efecto de cargar el menu de opciones
	public void onClick(){
		Debug.Log("Click en opciones");
		Constants.fadeInFadeOut(optionsMenu,mainMenu);
	}
}
}
