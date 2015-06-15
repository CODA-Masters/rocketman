using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

/*
Script principal de accion del juego.
Se implementa el control del personaje y
elementos graficos en la pantalla de juego.
*/

namespace ProgressBar{

public class PlayerMovement : MonoBehaviour {

	public float speed = 10f;
	public float angleFactor = 40.0f;
	private float buttonPressTime = 0.0f;
	public float jumpTop = 1.5f;
	private Rigidbody2D rb;
	private Animator animator;
	int phase;
	float angle;
	float timeCounter;
	GameObject Bar;
	GameObject Arc;
	GameObject Arrow;
	GameObject Background;
	GameObject fire;
	GameObject RetryButton, MenuButton;
	GameObject FinalScorePanel, HighScorePanel;
	GameObject ScorePanel;
	bool isJumping;
	bool dead;
	bool startJumping;
	bool topAngleReached;
	float percent;
	int score;
	float posInicial;
	GameObject platform;
	GameObject sound_Jetpack;
	GameObject sound_Die;
	GameObject sound_Score;
	GameObject sound_Power;
	BoxCollider2D bc;
	
	const int ANGLE_MODE = 0;
	const int JUMP_MODE = 1;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		phase = ANGLE_MODE;
		angle = 15;
		Bar = GameObject.Find ("PowerBar");
		Arc = GameObject.Find ("ArcImages");
		Background = GameObject.Find("outer-space1");
		Arrow = GameObject.Find ("arrow");
		Arrow.transform.localRotation = Quaternion.Euler (0, 0, angle);
		RetryButton = GameObject.Find ("RetryButton");
		MenuButton = GameObject.Find ("MenuButton");
		FinalScorePanel = GameObject.Find ("FinalScorePanel");
		HighScorePanel = GameObject.Find ("HighScorePanel");
		isJumping = false;
		fire = GameObject.Find ("fire");
		fire.GetComponent<ParticleSystem> ().Stop ();
		dead = false;
		percent = 0;
		ScorePanel = GameObject.Find ("ScorePanel");
		score = 0;
		platform =  GameObject.FindGameObjectWithTag("Platform");
		posInicial = transform.position.x;
		sound_Jetpack = GameObject.Find ("sound_Jetpack");
		sound_Die = GameObject.Find ("sound_Die");
		sound_Score = GameObject.Find ("sound_Score");
		sound_Power = GameObject.Find ("sound_Power");
		bool startJumping = false;
		topAngleReached = false;
		bc = Background.GetComponent<BoxCollider2D> ();
		timeCounter = 0;
		
	}
	// Funcion de movimiento
	void Movement(){
		// Si pulsamos la pantalla
		if(Input.GetMouseButton(0)){ 
			buttonPressTime += Time.deltaTime; // Tiempo de boton presionado acumulado
			if(buttonPressTime >= jumpTop){ // Capamos la potencia maxima que se puede alcanzar
				buttonPressTime = jumpTop;
			}
			// Cargamos la barra de potencia si la fase actual es la de salto
			if(phase == JUMP_MODE){
				percent = buttonPressTime / jumpTop;
				Bar.GetComponent<ProgressRadialBehaviour>().SetFillerSize(percent);
				if(!sound_Power.GetComponent<AudioSource>().isPlaying && FMG.Constants.getAudioVolume()==1){
					sound_Power.GetComponent<AudioSource>().Play();
				}
				
			}
			// Movemos la flecha en direccion que marca nuestro dedo si la fase es angulo
			// Capamos los angulos minimo y maximo para no permitir saltos indeseados.
			if(phase == ANGLE_MODE){
				Vector2 v = Input.mousePosition - Arrow.transform.position;
				if(angle <= 100 && angle >= 5 && !topAngleReached){
					angle = Mathf.Atan2(v.y,v.x)*Mathf.Rad2Deg;
				}
				else{
					topAngleReached  = true;
					timeCounter += Time.deltaTime;
					if(angle > 100)
						angle = 90;
					if(angle < 5)
						angle = 15;
				}
				if(topAngleReached){
					if(timeCounter > 0.3f){
						timeCounter = 0;
						topAngleReached = false;
					}
				}
				// Movemos el grafico de la flecha al mismo tiempo
				Arrow.transform.localRotation = Quaternion.Euler (0, 0, angle);
			}
			
		}
		// Soltamos el dedo
		if(Input.GetMouseButtonUp(0)){ 
			
			timeCounter = 0;
			topAngleReached = false;
			
			if(!startJumping){
				// Termina la fase de angulo
				if(phase == ANGLE_MODE){
					Bar.GetComponent<ProgressRadialBehaviour>().SetFillerSize(0);
					angle = Arrow.transform.eulerAngles.z * Mathf.Deg2Rad;
					buttonPressTime = 0;
				}
				
				//Termina la fase de salto
				if(phase == JUMP_MODE){
					startJumping = true;
					Arc.GetComponent< Transform > ().localScale = new Vector3 (1, 1, 1);
					Arrow.transform.rotation = Quaternion.Euler(0,0,15f);
					Bar.GetComponent<ProgressRadialBehaviour>().SetFillerSize(0);
					
				}
				
				// Alternamos entre una fase y otra
				if(phase == ANGLE_MODE){ phase = JUMP_MODE; }
				else{ phase = ANGLE_MODE; }
			}
		}
	}

	// Graficos y movimiento
	void Update(){
		// Seleccionamos la animacion correspondiente a la skin seleccionada
		if (!isJumping) {
			Movement ();
			switch (PlayerPrefs.GetInt ("selectedItem")) {
				case 0:
					animator.SetInteger ("state", 0);
					break;
				case 1:
					animator.SetInteger ("state", 8);
					break;
				case 2:
					animator.SetInteger ("state", 4);
					break;
				case 3:
					animator.SetInteger ("state", 6);
					break;
				case 4:
					animator.SetInteger("state",2);
					break;
			}
		} else {
			switch (PlayerPrefs.GetInt("selectedItem")){
				case 0:
					animator.SetInteger ("state", 1);
					break;
				case 1:
					animator.SetInteger ("state", 9);
					break;
				case 2:
					animator.SetInteger ("state", 5);
					break;
				case 3:
					animator.SetInteger ("state", 7);
					break;
				case 4:
					animator.SetInteger("state",3);
					break;
			}
		}
	}
	
	// Calculos fisicos
	void FixedUpdate(){
		
		// Si el personaje muere actualizamos el ranking y mostramos las opciones de reintentar y menu
		if (transform.position.y < (Background.transform.position.y - bc.size.y)) {
			if (!dead) {
				Time.timeScale = 0;
				if (score > PlayerPrefs.GetInt ("highscore")) {
					PlayerPrefs.SetInt ("highscore", score);
					if(Social.localUser.authenticated){
						Social.ReportScore(score, "CgkIh-a8y9sQEAIQAA", (bool success) => {});
					} else {
						Social.localUser.Authenticate((bool success) => {});
					}
				}
				if(FMG.Constants.getAudioVolume()==1)
					sound_Die.GetComponent<AudioSource> ().Play ();
				sound_Jetpack.GetComponent<AudioSource> ().Stop ();
				RetryButton.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
				MenuButton.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
				FinalScorePanel.GetComponentInChildren<Text> ().text = "Your score: " + score;
				FinalScorePanel.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
				HighScorePanel.GetComponentInChildren<Text> ().text = "High score: " + PlayerPrefs.GetInt("highscore");
				HighScorePanel.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
			}
			dead = true;
		}
		// Si se encuentra quieto paramos la velocidad. Si empieza a saltar aplicamos una fuerza con su angulo calculado
		if (!isJumping) {
			if (startJumping) {
				rb.velocity = new Vector2 (Mathf.Cos (angle) * buttonPressTime * speed, Mathf.Sin (angle) * buttonPressTime * speed * 1.5f);
				startJumping = false;
				buttonPressTime = 0;
			}
			
		}
		// La puntuacion se obtiene a partir de la distancia de la plataforma actual a la siguiente
		int scorePrev = score;
		score = (int)((transform.position.x - posInicial + 2) / platform.GetComponent<BoxCollider2D> ().bounds.size.x);
		ScorePanel.GetComponentInChildren<Text> ().text = "" + score;
		if (score > scorePrev && FMG.Constants.getAudioVolume()==1)
			sound_Score.GetComponent<AudioSource> ().Play ();
		
		// Si obtenemos la puntuacion que requieren los logros de Google Play Services los desbloqueamos
		if (score == 10) {
			Social.ReportProgress ("CgkIh-a8y9sQEAIQCQ", 100.0f, (bool success) => {});
		} else if (score == 25) {
			Social.ReportProgress ("CgkIh-a8y9sQEAIQBg", 100.0f, (bool success) => {});
		} else if (score == 50) {
			Social.ReportProgress ("CgkIh-a8y9sQEAIQBw", 100.0f, (bool success) => {});
		} else if (score == 100) {
			Social.ReportProgress ("CgkIh-a8y9sQEAIQCA", 100.0f, (bool success) => {});
		}
	}

	// Al entrar en contacto con una plataforma paramos el movimiento
	void OnCollisionEnter2D(Collision2D collision){
		Arc.GetComponent< Transform > ().localScale = new Vector3 (1, 1, 1);
		isJumping = false;
		fire.GetComponent<ParticleSystem> ().Stop ();
		sound_Jetpack.GetComponent<AudioSource>().Stop();
		rb.velocity = new Vector3 (0, 0, 0);
	}

	// Al salir volvemos a saltar
	void OnCollisionExit2D(Collision2D collision){
		Arc.GetComponent< Transform > ().localScale = new Vector3 (0, 0, 0);
		isJumping = true;
		fire.GetComponent<ParticleSystem> ().Play ();
		if(FMG.Constants.getAudioVolume()==1)
			sound_Jetpack.GetComponent<AudioSource>().Play();
	}
}
}