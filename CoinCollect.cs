using UnityEngine;
using System.Collections;

public class CoinCollect : MonoBehaviour {

	public Vector3 rotationVelocity, offset;
	public float recycleOffset, spawnChance;
	public AudioSource collected;
	private int coin = 0;

	// Use this for initialization
	void Start () {

		GameEventManager.GameOver += GameOver;
		gameObject.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {

		if(transform.localPosition.x + recycleOffset < PlayerController.distanceTraveled)
		{
			gameObject.SetActive(false);
			return;
		}

		transform.Rotate (rotationVelocity * Time.deltaTime);
	
	}

	void OnTriggerEnter(Collider info)
	{
		if (info.tag == "Player") 
		{
			//Debug.Log("Coin");
			collected.Play();
			coin++;
			GUIManager.Coins(coin);
			gameObject.SetActive(false);

		}
	}

	public void SpawnIfAvailable (Vector3 position) {
		if (gameObject.activeSelf || spawnChance <= Random.Range (0f, 100f)) {
			return;
		} else {
			transform.localPosition = position + offset;
			gameObject.SetActive (true);
		}
	}


	private void GameOver () {
		gameObject.SetActive(false);
		coin = 0;
	}
}
