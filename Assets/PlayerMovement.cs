using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 4f;
	public float angleFactor = 10.0f;
	float buttonPressTime = 0.0f;
	Rigidbody2D rb;
	int phase;
	float angle;
	GameObject Bar;

	const int ANGLE_MODE = 0;
	const int JUMP_MODE = 1;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		phase = ANGLE_MODE;
		angle = 0;
		Bar = GameObject.Find ("DriveBar");
	}

	void Update(){
		Movement ();
	}
	
	void Movement(){
		if(Input.GetMouseButton(0)){ // left click pressed
			buttonPressTime += Time.deltaTime; // calculate time pressed
			Debug.Log ("Tiempo de problemo: " + buttonPressTime);
		}
		if(Input.GetMouseButtonUp(0)){ // left click released

			// Choose angle phase
			if(phase == ANGLE_MODE){
				angle = (buttonPressTime*angleFactor % 90) * Mathf.Deg2Rad;
				Bar.GetComponent< GUIBarScript > ().ScaleSize = 1;
				Bar.GetComponent< GUIBarScript > ().DisplayText = true;
			}

			//Choose jump speed phase
			if(phase == JUMP_MODE){
				rb.velocity = new Vector2( Mathf.Cos(angle) * buttonPressTime * speed, Mathf.Sin(angle) * buttonPressTime * speed * 2);
			}
			buttonPressTime = 0;
			if(phase == ANGLE_MODE){ phase = JUMP_MODE; }
			else{ phase = ANGLE_MODE; }
		}
	}
}
