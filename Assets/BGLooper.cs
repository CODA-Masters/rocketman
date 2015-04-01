using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {
	
	int numBGPanels = 4;
	int numPlatforms = 8;
	
	void OnTriggerEnter2D(Collider2D collider){
		
		Vector3 pos = collider.transform.position;
		float widthOfBGObject = 0;
		if (collider.tag == "Platform") {
			widthOfBGObject = ((BoxCollider2D)collider).size.x*2f;
			pos.x += (widthOfBGObject * numPlatforms);
		} else {
			widthOfBGObject = ((BoxCollider2D)collider).size.x*1.655f;
			pos.x += (widthOfBGObject * numBGPanels);
		}
		collider.transform.position = pos;
	}
}