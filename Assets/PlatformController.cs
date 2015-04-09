using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

	private GameObject player;
	private GameObject[] platforms;

	public float MaxPlatformHeight;
	
	public float MinPlatformHeight;
	
	private float gemYPosition;

	private float RandomYDistance;
	
	private int hasGem;
	
	// Use this for initialization
	
	void Start () 
		
	{
		platforms = new GameObject[10];
		for (int i = 0; i < 10; i++){
			GameObject platform = GameObject.Find ("platform"+(i+1));
			platforms[i] = platform;
		}
			

		player = GameObject.FindGameObjectWithTag ("Player");
		
		
		for(int i = 0; i < platforms.Length; i++){


			RandomYDistance = Random.Range(MinPlatformHeight, MaxPlatformHeight);
			if(i == 0){
				player.transform.Translate (0, RandomYDistance, 0);
			}
			
			platforms[i].transform.Translate(0, RandomYDistance, 0);
			
			hasGem = Random.Range(0,2);
			if(hasGem == 0){
				platforms[i].GetComponentInChildren<PolygonCollider2D>().transform.localScale = new Vector3 (0, 0, 0);
			}
			
			if(i != 0){
				gemYPosition = (platforms[i].transform.position.y + platforms[i-1].transform.position.y)/ 2;
				//platforms[i].transform.FindChild("spaceGem").transform.position=new Vector2(brozo);
			}
		}
		
	}


	void Update () 
		
	{ 

		
	}

}
