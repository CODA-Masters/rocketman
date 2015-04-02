using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {
	
	int numBGPanels = 4;
	int numPlatforms = 8;
	private float RandomYDistance; 
	public float MaxPlatformHeight;
	public float MinPlatformHeight;

	
	void OnTriggerEnter2D(Collider2D collider){
		
		Vector3 pos = collider.transform.position;
		float widthOfBGObject = 0;
		if (collider.tag == "Platform") {
			widthOfBGObject = ((BoxCollider2D)collider).size.x*2f;
			pos.x += (widthOfBGObject * numPlatforms);
			RandomYDistance = Random.Range(MinPlatformHeight, MaxPlatformHeight);
			collider.transform.Translate(0, RandomYDistance, 0);
		} else if (collider.tag == "Background"){
			widthOfBGObject = ((BoxCollider2D)collider).size.x*1.655f;
			pos.x += (widthOfBGObject * numBGPanels);
		}
		collider.transform.position = pos;
	}
}