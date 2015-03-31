using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	int numBGPanels = 4;

	void OnTriggerEnter2D(Collider2D collider){
		float widthOfBGObject = ((BoxCollider2D)collider).size.x*1.5f;

		Vector3 pos = collider.transform.position;
		pos.x += (widthOfBGObject * numBGPanels);
		collider.transform.position = pos;
	}
}
