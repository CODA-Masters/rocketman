using UnityEngine;
using System.Collections;

// Script que inicializa las plataformas en su posicion aleatoria
public class PlatformController : MonoBehaviour {

	private GameObject player;
	private GameObject[] platforms;

	public float MaxPlatformY;
	public float MinPlatformY;

	public float MaxPlatformX;
	public float MinPlatformX;
	
	private float gemYPosition;

	private float RandomYDistance;
	private float RandomXDistance;
	
	private int hasGem, hasBlackHole;
	
	// Use this for initialization
	
	void Start () 
		
	{
		player = GameObject.FindGameObjectWithTag ("Player");

		/* Metemos las plataformas en un array para ordenarlas y le asignamos una
		posicion aleatoria */
		
		platforms = new GameObject[10];
		for (int i = 0; i < 10; i++){
			GameObject platform = GameObject.Find ("platform"+(i+1));
			platforms[i] = platform;

			RandomYDistance = Random.Range(MinPlatformY, MaxPlatformY);
			RandomXDistance = Random.Range(MinPlatformX, MaxPlatformX);
			
			if(i == 0){
				player.transform.Translate (RandomXDistance, RandomYDistance, 0);
			}
			if(i != 4)
				platforms[i].transform.Translate(RandomXDistance, RandomYDistance, 0);
		}
		
		// Despues calculamos si tienen gema o agujero negro de forma aleatoria
		// Se calcula tambien la altura de la gema con respecto a las plataformas
		for(int i = 0; i < platforms.Length-1; i++){

			hasGem = Random.Range(0,2);
			if(hasGem == 0){
				platforms[i].GetComponentInChildren<PolygonCollider2D>().transform.localScale = new Vector3 (0, 0, 0);
			}

			float max = Mathf.Max(platforms[i].transform.position.y,platforms[i+1].transform.position.y);
			gemYPosition = max+Mathf.Abs (platforms[i].transform.position.y-platforms[i+1].transform.position.y);
			Vector3 pos = platforms[i].transform.FindChild("spaceGem").transform.position;
			pos.y = gemYPosition;
			platforms[i].transform.FindChild("spaceGem").transform.position = pos;

		}

		// Aparecer o no agujero negro
		hasBlackHole = Random.Range(0,2);
		if(hasBlackHole == 0){
			platforms[0].transform.GetChild(4).gameObject.SetActive(false);
		}
		else{
			platforms[0].transform.GetChild(4).gameObject.SetActive(true);
		}

		// Aparecer o no agujero negro
		hasBlackHole = Random.Range(0,2);
		if(hasBlackHole == 0){
			platforms[9].transform.GetChild(3).gameObject.SetActive(false);
		}
		else{
			platforms[9].transform.GetChild(3).gameObject.SetActive(true);
		}
		
	}


	void Update () 
		
	{ 

		
	}

}
