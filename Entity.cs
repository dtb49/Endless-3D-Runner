using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public float health;
	public GameObject ragdoll;




	public void TakeDamage(float damage)
	{
		health -= damage;

		if (health <= 0) 
		{
			Die ();
		}
					
	}

	public void Die()
	{
		//Debug.Log("DIE");
		//cam.SetTarget (ragdoll.transform);
		Ragdoll r = (Instantiate (ragdoll, transform.position, transform.rotation) as GameObject).GetComponent<Ragdoll>();

		//Destroy (this.gameObject);
		//renderer.enabled = false;
		GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;

		//GameManager.SpawnPlayer ();
		GameEventManager.TriggerGameOver ();


	}
	
}
