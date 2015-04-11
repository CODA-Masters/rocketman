using UnityEngine;
using System.Collections;

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

	void OnTriggerEnter2D(Collider2D collider){
		timer = 0.0f;
		Player.GetComponent<Rigidbody2D> ().gravityScale = 0;
		Player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		contact = true;
	}

	void OnTriggerExit2D(Collider2D collider){
		Player.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
	}
	
	void Update(){
		timer += Time.deltaTime;
		if (contact && timer > 1) {
			Player.GetComponent<Rigidbody2D>().isKinematic = true;
			Player.transform.localScale = new Vector3(0,0,0);
			fire.GetComponent<ParticleSystem> ().Stop ();
			BallTransformation.GetComponent<ParticleSystem>().Play();
			sound_Jetpack.GetComponent<AudioSource>().Stop();

			if (this.name == "BlackHoleGood") {
				// Face to target
				Vector3 dir = BlackHoleDestGood.transform.position - Player.transform.position;
				float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
				Player.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

				Player.transform.Translate(Vector3.right * Time.deltaTime*5);
				BlackHoleDestGood.GetComponentInChildren<ParticleSystem> ().Play ();


				if(Player.transform.position.x >= BlackHoleDestGood.transform.position.x){
					Player.GetComponent<Rigidbody2D>().isKinematic = false;
					Player.GetComponent<Rigidbody2D>().gravityScale = 1;
					Player.transform.position = BlackHoleDestGood.transform.position;
					BlackHoleDestGood.GetComponentInChildren<ParticleSystem> ().Stop ();
					Player.transform.localScale = new Vector3(0.4f,0.4f,0.4f);
					BallTransformation.GetComponent<ParticleSystem>().Stop();
					contact = false;
					timer = 0.0f;
				}
			}

			else if (this.name == "BlackHoleBad") {
				// Face to target
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
					Player.transform.localScale = new Vector3(0.4f,0.4f,0.4f);
					BallTransformation.GetComponent<ParticleSystem>().Stop();
					contact = false;
					timer = 0.0f;
				}
				
			}
		}
	}
}
