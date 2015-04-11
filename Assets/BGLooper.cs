using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {
	
	int numBGPanels = 4;
	int numPlatforms = 10;
	private float RandomYDistance;
	private int hasGem;
	public float MaxPlatformHeight;
	public float MinPlatformHeight;

	
	void OnTriggerEnter2D(Collider2D collider){
		
		Vector3 pos = collider.transform.position;
		float widthOfBGObject = 0;
		if (collider.tag == "Platform") {
			// Mover plataforma en con eje Y aleatorio
			widthOfBGObject = ((BoxCollider2D)collider).size.x*1.6f;
			pos.x += (widthOfBGObject * numPlatforms);
			if(collider.name != "platform5"){
				RandomYDistance = Random.Range(MinPlatformHeight, MaxPlatformHeight);
				collider.transform.Translate(0, RandomYDistance, 0);
			}
			
			// Aparecer o no gema
			hasGem = Random.Range(0,2);
			if(hasGem == 0){
				collider.GetComponentInChildren<PolygonCollider2D>().transform.localScale = new Vector3 (0, 0, 0);
			}
			
		} else if (collider.tag == "Background"){
			widthOfBGObject = ((BoxCollider2D)collider).size.x*1.655f;
			pos.x += (widthOfBGObject * numBGPanels);
		}
		collider.transform.position = pos;
	}
}