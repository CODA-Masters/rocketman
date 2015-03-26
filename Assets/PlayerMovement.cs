using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 4f;
	public float angleFactor = 10.0f;
	float buttonPressTime = 0.0f;
	float jumpTop = 2f;
	Rigidbody2D rb;
	int phase;
	float angle;
	GameObject Bar;
	GameObject Arc;
	GameObject Arrow;
	float angleSum;

	const int ANGLE_MODE = 0;
	const int JUMP_MODE = 1;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		phase = ANGLE_MODE;
		angle = 0;
		Bar = GameObject.Find ("DriveBar");
		Arc = GameObject.Find ("ArcImages");
		Arrow = GameObject.Find ("arrow");
	}

	void Update(){
		Movement ();
	}
	
	void Movement(){
		if(Input.GetMouseButton(0)){ // left click pressed
			buttonPressTime += Time.deltaTime; // calculate time pressed
			if(buttonPressTime >= jumpTop){
				buttonPressTime = jumpTop;
			}
			float percent = buttonPressTime / jumpTop;
			Bar.GetComponent < GUIBarScript > ().SetNewValue(percent);
			//Debug.Log ("Tiempo de problemo: " + buttonPressTime);

			if(phase == ANGLE_MODE){
				float angleDeg = buttonPressTime*angleFactor;
				if(Arrow.transform.rotation.z <= 90){
					angle = (buttonPressTime*angleFactor) * Mathf.Deg2Rad;
					Arrow.transform.Rotate(0,0,angle);
				}
			} 
			//Debug.Log("Angulillo", ""+Arrow.transform.rotation.z);

		}
		if(Input.GetMouseButtonUp(0)){ // left click released

			// Angle phase ends
			if(phase == ANGLE_MODE){
				Bar.GetComponent< GUIBarScript > ().ScaleSize = 1;
				Bar.GetComponent< GUIBarScript > ().DisplayText = true;
				Bar.GetComponent < GUIBarScript > ().SetNewValue(0);
				Arc.GetComponent< Transform > ().localScale = new Vector3 (0, 0, 0);
				Arrow.transform.rotation = Quaternion.Euler(0,0,0);
			}

			//Jump speed phase ends
			if(phase == JUMP_MODE){
				rb.velocity = new Vector2( Mathf.Cos(angle) * buttonPressTime * speed, Mathf.Sin(angle) * buttonPressTime * speed * 2);
				Bar.GetComponent< GUIBarScript > ().ScaleSize = 0;
				Bar.GetComponent< GUIBarScript > ().DisplayText = false;
				Arc.GetComponent< Transform > ().localScale = new Vector3 (1, 1, 1);
			}
			buttonPressTime = 0;
			if(phase == ANGLE_MODE){ phase = JUMP_MODE; }
			else{ phase = ANGLE_MODE; }
		}
	}
}
