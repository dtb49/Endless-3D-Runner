using UnityEngine;
using System.Collections;

public class Sawblade : MonoBehaviour {

	//public float speed = 300;
	public Vector3 offset, rotationVelocity;
	public float recycleOffset, spawnChance;

	void Start () {
		GameEventManager.GameOver += GameOver;
		gameObject.SetActive(true);
	}
	// Update is called once per frame
	void Update () {

		if(transform.localPosition.x + recycleOffset < PlayerController.distanceTraveled)
		{
			gameObject.SetActive(false);
			return;
		}

		//transform.Rotate (Vector3.forward * speed * Time.deltaTime, Space.World);
		transform.Rotate(rotationVelocity * Time.deltaTime);
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player") 
		{
			c.GetComponent<Entity>().TakeDamage(10);
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
	}
}
