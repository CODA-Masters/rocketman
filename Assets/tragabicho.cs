using UnityEngine;
using System.Collections;

// Script para mover al personaje entre portales
public class tragabicho : MonoBehaviour {

	GameObject Player;
	GameObject BlackHoleDestGood;
	GameObject BlackHoleDestBad;
	GameObject BallTransformation;
	GameObject fire;
	GameObject sound_Jetpack;
	bool contact = false;
	float timer;

	void Start(){
		Player = GameObject.FindGameObjectWithTag("Player");
		BallTransformation = GameObject.Find ("BallTransformation");
		BlackHoleDestGood = GameObject.Find ("BlackHoleDestGood");
		BlackHoleDestBad = GameObject.Find ("BlackHoleDestBad");
		fire = GameObject.Find ("fire");
		sound_Jetpack = GameObject.Find ("sound_Jetpack");
		BlackHoleDestGood.GetComponentInChildren<ParticleSystem> ().Stop ();
		BlackHoleDestBad.GetComponentInChildren<ParticleSystem> ().Stop ();
	}

	// Cuando colisiona el portal con el jugador ponemos la gravedad a 0 y velocidad a 0
	void OnTriggerEnter2D(Collider2D collider){
		timer = 0.0f;
		Player.GetComponent<Rigidbody2D> ().gravityScale = 0;
		Player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		contact = true;
	}
	// Cuando abandonamos el portal ponemos la gravedad a 0
	void OnTriggerExit2D(Collider2D collider){
		Player.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
	}
	
	void Update(){
		// Esperamos a que pase un segundo para iniciar la teleportacion
		timer += Time.deltaTime;
		if (contact && timer > 1) {
			// Para teleportarnos ocultamos el personaje y mostramos un efecto de particulas
			Player.GetComponent<Rigidbody2D>().isKinematic = true;
			Player.transform.localScale = new Vector3(0,0,0);
			fire.GetComponent<ParticleSystem> ().Stop ();
			BallTransformation.GetComponent<ParticleSystem>().Play();
			sound_Jetpack.GetComponent<AudioSource>().Stop();

			// En caso de ser un portal verde (bueno)
			if (this.name == "BlackHoleGood") {
				// Apuntamos al objetivo
				Vector3 dir = BlackHoleDestGood.transform.position - Player.transform.position;
				float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
				Player.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
				
				// Movemos al jugador hasta el objetivo
				Player.transform.Translate(Vector3.right * Time.deltaTime*5);
				BlackHoleDestGood.GetComponentInChildren<ParticleSystem> ().Play ();

				// Cuando llegamos deshacemos todas las transformaciones
				if(Player.transform.position.x >= BlackHoleDestGood.transform.position.x){
					Player.GetComponent<Rigidbody2D>().isKinematic = false;
					Player.GetComponent<Rigidbody2D>().gravityScale = 1;
					Player.transform.position = BlackHoleDestGood.transform.position;
					BlackHoleDestGood.GetComponentInChildren<ParticleSystem> ().Stop ();
					Player.transform.rotation = Quaternion.AngleAxis(0,Vector3.forward);
					Player.transform.localScale = new Vector3(2,2,1);
					BallTransformation.GetComponent<ParticleSystem>().Stop();
					contact = false;
					timer = 0.0f;
				}
			}
			// Lo mismo que en el caso anterior, pero ahora nos movemos hacia atras
			else if (this.name == "BlackHoleBad") {
			
				Vector3 dir = Player.transform.position -  BlackHoleDestBad.transform.position;
				float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
				Player.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

				Player.transform.Translate(Vector3.left * Time.deltaTime*5);
				BlackHoleDestBad.GetComponentInChildren<ParticleSystem> ().Play ();


				if(Player.transform.position.x <= BlackHoleDestBad.transform.position.x){
					Player.GetComponent<Rigidbody2D>().isKinematic = false;
					Player.GetComponent<Rigidbody2D>().gravityScale = 1;
					Player.transform.position = BlackHoleDestBad.transform.position;
					BlackHoleDestBad.GetComponentInChildren<ParticleSystem> ().Stop ();
					Player.transform.rotation = Quaternion.AngleAxis(0,Vector3.forward);
					Player.transform.localScale = new Vector3(2,2,1);
					BallTransformation.GetComponent<ParticleSystem>().Stop();
					contact = false;
					timer = 0.0f;
				}
				
			}
		}
	}
}
