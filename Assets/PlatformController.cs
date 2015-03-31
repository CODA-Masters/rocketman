using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

	public GameObject platform1, platform2, platform3, platform4; 

	public float MaxPlatformHeight;
	
	public float MinPlatformHeight;

	private float RandomYDistance; 
	
	// Use this for initialization
	
	void Start () 
		
	{

		platform1 = GameObject.FindGameObjectWithTag ("Plataforma1");
		platform2 = GameObject.FindGameObjectWithTag ("Plataforma2");
		platform3 = GameObject.FindGameObjectWithTag ("Plataforma3");
		platform4 = GameObject.FindGameObjectWithTag ("Plataforma4");

		
		RandomYDistance = Random.Range(MinPlatformHeight, MaxPlatformHeight);
		platform1.transform.Translate(0, RandomYDistance, 0);

		RandomYDistance = Random.Range(MinPlatformHeight, MaxPlatformHeight);
		platform2.transform.Translate(0, RandomYDistance, 0);

		RandomYDistance = Random.Range(MinPlatformHeight, MaxPlatformHeight);
		platform3.transform.Translate(0, RandomYDistance, 0);

		RandomYDistance = Random.Range(MinPlatformHeight, MaxPlatformHeight);
		platform4.transform.Translate(0, RandomYDistance, 0);	
		
	}


	void Update () 
		
	{ 

		
	}

}
