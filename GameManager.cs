using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public  GameObject player;
	private  GamerCamera cam;

	// Use this for initialization
	void Start () {
		cam = GetComponent<GamerCamera> ();
		SpawnPlayer ();
	}
	
	public void SpawnPlayer()
	{
		cam.SetTarget((Instantiate (player, Vector3.zero, Quaternion.identity) as GameObject).transform);
	}
}
