using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour {
	public float speed = 0;
	
	SpriteRenderer renderer;
	
	void Start(){
		renderer = this.GetComponent<SpriteRenderer>();
	}
	
	void Update(){
		renderer.material.mainTextureOffset = new Vector2((Time.time * speed) % 1, 0f);
	}
}
