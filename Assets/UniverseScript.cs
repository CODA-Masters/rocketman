using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UniverseScript : MonoBehaviour {
	GameObject Bar;
	GameObject RetryButton;
	GameObject FinalScorePanel;
	GameObject bg_music;
	GameObject Sounds;
	GameObject GemsUI;
	GameObject HUDCanvas;
	public int gems;
	private static UniverseScript _instance;

	void Awake(){
		Time.timeScale = 1;
		if(!_instance){
			_instance = this;
		}
		else{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
		
		// Inicialization
		GemsUI = GameObject.Find("GemsUI");
		RetryButton = GameObject.Find ("RetryButton");
		RetryButton.GetComponent<RectTransform> ().localScale = new Vector3 (0, 0, 0);
		FinalScorePanel = GameObject.Find ("FinalScorePanel");
		FinalScorePanel.GetComponent<RectTransform> ().localScale = new Vector3 (0, 0, 0);
		gems = 0;
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
		bg_music = GameObject.Find ("bg_music");
	}
	
	// Update is called once per frame
	void Update () {
		if (GemsUI == null){
			GemsUI = GameObject.Find("GemsUI");
			GemsUI.GetComponentInChildren<Text>().text = gems+"";
		}
		GemsUI.GetComponentInChildren<Text>().text = gems+"";
	}
	
	public void addGem(){
		gems++;
	}
	public int getGems(){
		return gems;
	}
}
