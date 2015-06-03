using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {
	
	int numBGPanels = 4;
	int numPlatforms = 10;
	private float RandomYDistance;
	private float RandomXDistance;
	private int hasGem;

	public float MaxPlatformY;
	public float MinPlatformY;
	
	public float MaxPlatformX;
	public float MinPlatformX;

	private GameObject previousPlatform;

	
	void OnTriggerEnter2D(Collider2D collider){
		
		Vector3 pos = collider.transform.position;
		float widthOfBGObject = 0;
		if (collider.tag == "Platform") {
			// Mover plataforma en con eje Y aleatorio
			widthOfBGObject = ((BoxCollider2D)collider).size.x*1.6f;
			pos.x += (widthOfBGObject * numPlatforms);
			if(collider.name != "platform5"){
				RandomYDistance = Random.Range(MinPlatformY, MaxPlatformY);
				RandomXDistance = Random.Range(MinPlatformX, MaxPlatformX);

				pos.x += RandomXDistance;

				collider.transform.position = pos;
				collider.transform.position = new Vector3(pos.x, RandomYDistance, pos.z);
			}
			
			// Aparecer o no gema
			hasGem = Random.Range(0,2);
			if(hasGem == 0 && collider.name!="platform10"){
				collider.GetComponentInChildren<PolygonCollider2D>().transform.localScale = new Vector3 (0, 0, 0);
			}
			else if (hasGem==1){
				collider.GetComponentInChildren<PolygonCollider2D>().transform.localScale = new Vector3 (1, 1, 1);
			}

			if(collider.name != "platform1" && collider.name != "platform10"){

				int currentPlatform = int.Parse(collider.name.Substring(collider.name.Length-1));
				previousPlatform = GameObject.Find(collider.name.Replace(currentPlatform+"",(currentPlatform-1+"")));

				float max = Mathf.Max(collider.transform.position.y,previousPlatform.transform.position.y);
				float gemYPosition = max+Mathf.Abs (collider.transform.position.y-previousPlatform.transform.position.y);
				Vector3 pos2 = collider.transform.FindChild("spaceGem").transform.position;
				pos2.y = gemYPosition;
				collider.transform.FindChild("spaceGem").transform.position = pos2;
			}
			
		} else if (collider.tag == "Background"){
			widthOfBGObject = ((BoxCollider2D)collider).size.x*1.655f;
			pos.x += (widthOfBGObject * numBGPanels);
			collider.transform.position = new Vector3(pos.x, 0, pos.z);
		}
	}
}