using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	float speed = 4f;
	float angleFactor = 10f;
	float buttonPressTime = 0.0f;
	Rigidbody2D rb;
	int phase;
	float angle;

	const int ANGLE_MODE = 0;
	const int JUMP_MODE = 1;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		phase = ANGLE_MODE;
		angle = 0;
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
			if(phase == ANGLE_MODE){
				angle = (buttonPressTime*angleFactor % 90) * Mathf.Deg2Rad;
				phase = JUMP_MODE;
			}
			if(phase == JUMP_MODE){

				rb.velocity = new Vector2( Mathf.Cos(angle) * buttonPressTime * speed, Mathf.Sin(angle) * buttonPressTime * speed);
				phase = ANGLE_MODE;
			}
			buttonPressTime = 0;
		}
	}
}
