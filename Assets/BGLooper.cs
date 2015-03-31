using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	int numBGPanels = 4;
	int numPlatforms = 8;

	void OnTriggerEnter2D(Collider2D collider){

		Vector3 pos = collider.transform.position;
		if (collider.tag == "Platform") {
			float widthOfBGObject = ((BoxCollider2D)collider).bounds.size.x;
			pos.x += (widthOfBGObject * numPlatforms);
		} else {
			float widthOfBGObject = ((BoxCollider2D)collider).bounds.size.x;
			pos.x += (widthOfBGObject * numBGPanels);
		}
		collider.transform.position = pos;
		//collider.attachedRigidbody.transform.position = pos;
	}
}
