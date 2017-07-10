using UnityEngine;
using System.Collections;

public class GamerCamera : MonoBehaviour {

	private Transform target;
	private float trackSpeed = 10;

	public void SetTarget(Transform t)
	{
		target = t;
	}

	void LateUpdate() 
	{
		if (target)
		{
			float x = IncrementTowards(transform.position.x, target.position.x,trackSpeed);	
			float y = IncrementTowards(transform.position.y, target.position.y,trackSpeed);
			//float z = IncrementTowards(transform.position.z, target.position.z,trackSpeed);
			transform.position = new Vector3(x,y,transform.position.z);
		}
	}

	//Increase n towards target by a
	private float IncrementTowards(float n, float target, float a)
	{
		if (n == target) 
		{
			return n;
		}
		else 
		{
			float dir = Mathf.Sign (target - n); //does n need to be increased or decreased to reach target
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign (target-n))? n: target; //if n has passed target return targeet otherwise return n
		}
		
	}
}
