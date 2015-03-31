using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

	public GameObject platform1, platform2, platform3, platform4, platform5, platform6, platform7, platform8, player; 

	public float MaxPlatformHeight;
	
	public float MinPlatformHeight;

	private float RandomYDistance; 
	
	// Use this for initialization
	
	void Start () 
		
	{

		platform1 = GameObject.Find("platform1");
		platform2 = GameObject.Find("platform2");
		platform3 = GameObject.Find("platform3");
		platform4 = GameObject.Find("platform4");
		platform5 = GameObject.Find("platform5");
		platform6 = GameObject.Find("platform6");
		platform7 = GameObject.Find("platform7");
		platform8 = GameObject.Find("platform8");

		player = GameObject.FindGameObjectWithTag ("Player");

		
		RandomYDistance = Random.Range(MinPlatformHeight, MaxPlatformHeight);
		platform1.transform.Translate(0, RandomYDistance, 0);
		player.transform.Translate (0, RandomYDistance, 0);

		RandomYDistance = Random.Range(MinPlatformHeight, MaxPlatformHeight);
		platform2.transform.Translate(0, RandomYDistance, 0);

		RandomYDistance = Random.Range(MinPlatformHeight, MaxPlatformHeight);
		platform3.transform.Translate(0, RandomYDistance, 0);

		RandomYDistance = Random.Range(MinPlatformHeight, MaxPlatformHeight);
		platform4.transform.Translate(0, RandomYDistance, 0);

		RandomYDistance = Random.Range(MinPlatformHeight, MaxPlatformHeight);
		platform5.transform.Translate(0, RandomYDistance, 0);	

		RandomYDistance = Random.Range(MinPlatformHeight, MaxPlatformHeight);
		platform6.transform.Translate(0, RandomYDistance, 0);	

		RandomYDistance = Random.Range(MinPlatformHeight, MaxPlatformHeight);
		platform7.transform.Translate(0, RandomYDistance, 0);	

		RandomYDistance = Random.Range(MinPlatformHeight, MaxPlatformHeight);
		platform8.transform.Translate(0, RandomYDistance, 0);	
		
	}


	void Update () 
		
	{ 

		
	}

}
