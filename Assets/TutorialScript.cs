using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {

	GameObject Panel1, Panel2;

	public void onClick(){
		Panel1 = GameObject.Find ("Panel1");
		Panel2 = GameObject.Find ("Panel2");

		if(Panel1.transform.localScale.x == 1){
			Panel1.transform.localScale = new Vector3(0,0,0);
			Panel2.transform.localScale = new Vector3(1,1,1);
		}

		else if (Panel2.transform.localScale.x == 1){
			Panel2.transform.localScale = new Vector3(0,0,0);
			this.transform.localScale = new Vector3(0,0,0);
			PlayerPrefs.SetInt ("watched_tutorial",1);
			Time.timeScale = 1;
		}
	}
}