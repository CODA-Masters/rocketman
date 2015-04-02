using UnityEngine;
using System.Collections;

public class UniverseScript : MonoBehaviour {
	GameObject Bar;
	GameObject RetryButton;
	GameObject FinalScorePanel;
	GameObject bg_music;
	GameObject Sounds;

	void Awake(){
		DontDestroyOnLoad(gameObject);
		Sounds = GameObject.Find ("Sounds");
		bg_music = GameObject.Find ("bg_music");
		DontDestroyOnLoad (Sounds);
		DontDestroyOnLoad (bg_music);
		if (! bg_music.GetComponent<AudioSource> ().isPlaying) {
			bg_music.GetComponent<AudioSource> ().Play();
		}
	}

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		RetryButton = GameObject.Find ("RetryButton");
		RetryButton.GetComponent<RectTransform> ().localScale = new Vector3 (0, 0, 0);
		FinalScorePanel = GameObject.Find ("FinalScorePanel");
		FinalScorePanel.GetComponent<RectTransform> ().localScale = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
