﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ProgressBar{

public class PlayerMovement : MonoBehaviour {

	public float speed = 10f;
	public float angleFactor = 40.0f;
	float buttonPressTime = 0.0f;
	public float jumpTop = 1.5f;
	Rigidbody2D rb;
	int phase;
	float angle;
	GameObject Bar;
	GameObject Arc;
	GameObject Arrow;
	GameObject Background;
	GameObject fire;
	GameObject RetryButton;
	GameObject FinalScorePanel;
	GameObject ScorePanel;
	bool isJumping;
	bool dead;
	float percent;
	int score;
	float posInicial;
	GameObject platform;
	GameObject sound_Jetpack;
	GameObject sound_Die;
	GameObject sound_Score;
	GameObject sound_Power;
	
	const int ANGLE_MODE = 0;
	const int JUMP_MODE = 1;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		phase = ANGLE_MODE;
		angle = 15;
		Bar = GameObject.Find ("PowerBar");
		Arc = GameObject.Find ("ArcImages");
		Background = GameObject.Find("outer-space1");
		Arrow = GameObject.Find ("arrow");
		Arrow.transform.localRotation = Quaternion.Euler (0, 0, angle);
		RetryButton = GameObject.Find ("RetryButton");
		FinalScorePanel = GameObject.Find ("FinalScorePanel");
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
		
	}

	void Update(){
		if (!isJumping)
			Movement ();

		BoxCollider2D bc = Background.GetComponent<BoxCollider2D> ();
		
		// if DIE
		if (transform.position.y < (Background.transform.position.y-bc.size.y)) {
			if(!dead){
				Time.timeScale = 0;
				sound_Die.GetComponent<AudioSource>().Play();
				sound_Jetpack.GetComponent<AudioSource>().Stop();
				RetryButton.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
				FinalScorePanel.GetComponentInChildren<Text>().text = "Your score: " + score;
				FinalScorePanel.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
			}
			dead = true;
		}
		int scorePrev = score;
		score = (int)((transform.position.x - posInicial)/platform.GetComponent<BoxCollider2D>().bounds.size.x);
		ScorePanel.GetComponentInChildren<Text> ().text = ""+score;
		if(score > scorePrev)
			sound_Score.GetComponent<AudioSource>().Play();
		
	}
	
	void Movement(){
		if(Input.GetMouseButton(0)){ // left click pressed
			buttonPressTime += Time.deltaTime; // calculate time pressed
			if(buttonPressTime >= jumpTop){
				buttonPressTime = jumpTop;
			}
			
			if(phase == JUMP_MODE){
				percent = buttonPressTime / jumpTop;
				Bar.GetComponent<ProgressRadialBehaviour>().SetFillerSize(percent);
				if(!sound_Power.GetComponent<AudioSource>().isPlaying){
					sound_Power.GetComponent<AudioSource>().Play();
				}
				
			}

			if(phase == ANGLE_MODE){
				if(Arrow.transform.localRotation.z <= 90){
					angle = 15f+(buttonPressTime*angleFactor);
					Arrow.transform.localRotation = Quaternion.Euler (0, 0, angle);
				}
			}

		}
		if(Input.GetMouseButtonUp(0)){ // left click released

			// Angle phase ends
			if(phase == ANGLE_MODE){
				Bar.GetComponent<ProgressRadialBehaviour>().SetFillerSize(0);
				angle = Arrow.transform.eulerAngles.z * Mathf.Deg2Rad;
			}

			//Jump speed phase ends
			if(phase == JUMP_MODE){
				rb.velocity = new Vector2( Mathf.Cos(angle) * buttonPressTime * speed, Mathf.Sin(angle) * buttonPressTime * speed * 1.5f);
				Arc.GetComponent< Transform > ().localScale = new Vector3 (1, 1, 1);
				Arrow.transform.rotation = Quaternion.Euler(0,0,15f);
				Bar.GetComponent<ProgressRadialBehaviour>().SetFillerSize(0);
				
			}
			buttonPressTime = 0;
			if(phase == ANGLE_MODE){ phase = JUMP_MODE; }
			else{ phase = ANGLE_MODE; }
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		Arc.GetComponent< Transform > ().localScale = new Vector3 (1, 1, 1);
		isJumping = false;
		fire.GetComponent<ParticleSystem> ().Stop ();
		sound_Jetpack.GetComponent<AudioSource>().Stop();
				

	}
	void OnCollisionExit2D(Collision2D collision){
		Arc.GetComponent< Transform > ().localScale = new Vector3 (0, 0, 0);
		isJumping = true;
		fire.GetComponent<ParticleSystem> ().Play ();
		sound_Jetpack.GetComponent<AudioSource>().Play();
	}
}
}