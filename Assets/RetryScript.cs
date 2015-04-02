using UnityEngine;
using System.Collections;
namespace FMG
{
	public class RetryButton : MonoBehaviour {
		
		public void onClick()
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}