using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace FMG
{
public class optionsScript : MonoBehaviour {
	public GameObject optionsMenu, mainMenu;

	public void onClick(){
		Debug.Log("Click en opciones");
		Constants.fadeInFadeOut(optionsMenu,mainMenu);
	}
}
}
