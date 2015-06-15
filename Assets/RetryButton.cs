using UnityEngine;
using System.Collections;

// Script asociado al boton de reintentar
namespace FMG
{
	public class RetryButton : MonoBehaviour {

		public void onClick()
		{
			// Al hacer click volvemos a cargar el nivel actual
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
