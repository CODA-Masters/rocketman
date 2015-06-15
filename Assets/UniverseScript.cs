using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Script controlador de la escena del gameplay
public class UniverseScript : MonoBehaviour {
	GameObject Bar;
	GameObject RetryButton, MenuButton;
	GameObject FinalScorePanel, HighScorePanel;
	GameObject bg_music;
	GameObject Sounds;
	GameObject GemsUI;
	GameObject HUDCanvas;
	GameObject Animator;
	GameObject Panel1, Panel2, OKButton;
	public int gems;
	private static UniverseScript _instance;

	// Al inciar
	void Awake(){
		// Paramos todos los audios que esten sonando excepto la musica de fondo de esta escena
		AudioSource[] allAudioSources = (AudioSource[])FindObjectsOfType(typeof(AudioSource));
		for (int i = 0; i < allAudioSources.Length; i++) {
			if(allAudioSources[i].name != "bg_music")
				allAudioSources [i].Stop ();
		}


		Time.timeScale = 1;
		if(!_instance){
			_instance = this;
		}
		else{
			Destroy(this.gameObject);
		}
		
		// No destruimos este objeto ni los que haga falta tener en memoria al reiniciar
		DontDestroyOnLoad(this.gameObject);
		
		// Inicializacion
		GemsUI = GameObject.Find("GemsUI");
		RetryButton = GameObject.Find ("RetryButton");
		MenuButton = GameObject.Find ("MenuButton");

		RetryButton.GetComponent<RectTransform> ().localScale = new Vector3 (0, 0, 0);
		MenuButton.GetComponent<RectTransform> ().localScale = new Vector3 (0, 0, 0);
		FinalScorePanel = GameObject.Find ("FinalScorePanel");
		HighScorePanel = GameObject.Find ("HighScorePanel");
		FinalScorePanel.GetComponent<RectTransform> ().localScale = new Vector3 (0, 0, 0);
		HighScorePanel.GetComponent<RectTransform> ().localScale = new Vector3 (0, 0, 0);

		Panel1 = GameObject.Find ("Panel1");
		Panel2 = GameObject.Find ("Panel2");
		OKButton = GameObject.Find ("OKButton");

		if (PlayerPrefs.GetInt ("watched_tutorial") == 0) {
			Panel2.transform.localScale = new Vector3 (0, 0, 0);
			Time.timeScale = 0;

		} else {
			Panel1.transform.localScale = new Vector3 (0, 0, 0);
			Panel2.transform.localScale = new Vector3 (0, 0, 0);
			OKButton.transform.localScale = new Vector3 (0, 0, 0);
		}

		Sounds = GameObject.Find ("Sounds");
		bg_music = GameObject.Find ("bg_music");
		DontDestroyOnLoad (Sounds);
		DontDestroyOnLoad (bg_music);
		if (! bg_music.GetComponent<AudioSource> ().isPlaying && FMG.Constants.getAudioVolume()==1) {
			bg_music.GetComponent<AudioSource> ().Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
		gems = PlayerPrefs.GetInt("gems");
		if (GemsUI == null){
			GemsUI = GameObject.Find("GemsUI");
		}
		
		if(GemsUI != null){
			GemsUI.GetComponentInChildren<Text>().text = gems+"";
		}
	}
	
	public void addGem(){
		gems++;
		PlayerPrefs.SetInt ("gems", gems);
	}
	public int getGems(){
		return PlayerPrefs.GetInt("gems");
	}
}
