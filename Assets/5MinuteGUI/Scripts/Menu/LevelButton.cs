using UnityEngine;
using System.Collections;
namespace FMG
{
	public class LevelButton : MonoBehaviour {
		public int levelIndex=0;

		public void onClick()
		{
			Debug.Log ("Loading level "+levelIndex);
			Application.LoadLevel(levelIndex);
		}
	}
}