using UnityEngine;
using System.Collections;

public class tragabicho : MonoBehaviour {

	GameObject Player;
	GameObject BlackHoleDestGood;
	GameObject BlackHoleDestBad;
	GameObject BallTransformation;
	GameObject fire;
	bool contact = false;
	
	void Start(){
		Player = GameObject.FindGameObjectWithTag("Player");
		BallTransformation = GameObject.Find ("BallTransformation");
		BlackHoleDestGood = GameObject.Find ("BlackHoleDestGood");
		BlackHoleDestBad = GameObject.Find ("BlackHoleDestBad");
		fire = GameObject.Find ("fire");
		BlackHoleDestGood.GetComponentInChildren<ParticleSystem> ().Stop ();
		BlackHoleDestBad.GetComponentInChildren<ParticleSystem> ().Stop ();
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		contact = true;
		Player.GetComponent<Rigidbody2D>().gravityScale = 0;
		Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
	}

	void OnTriggerExit2D(Collider2D collider){
		Player.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
	}
	
	void Update(){
		if (contact) {
			if(Player.transform.rotation.eulerAngles.z <= 10){
				Player.GetComponent<Rigidbody2D>().isKinematic = true;
				Player.transform.localScale = new Vector3(0,0,0);
				fire.GetComponent<ParticleSystem> ().Stop ();
				BallTransformation.GetComponent<ParticleSystem>().Play();

				if (this.name == "BlackHoleGood") {
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
					}
				}

				else if (this.name == "BlackHoleBad") {
					Player.transform.Translate(Vector3.left * Time.deltaTime*5);
					BlackHoleDestGood.GetComponentInChildren<ParticleSystem> ().Play ();

					if(Player.transform.position.x <= BlackHoleDestBad.transform.position.x){
						Player.GetComponent<Rigidbody2D>().isKinematic = false;
						Player.GetComponent<Rigidbody2D>().gravityScale = 1;
						Player.transform.position = BlackHoleDestBad.transform.position;
						BlackHoleDestBad.GetComponentInChildren<ParticleSystem> ().Stop ();
						Player.transform.localScale = new Vector3(0.4f,0.4f,0.4f);
						BallTransformation.GetComponent<ParticleSystem>().Stop();
						contact = false;
					}
					
				}
			}
		}
	}
}
