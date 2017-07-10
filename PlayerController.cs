using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : Entity {

	public static float distanceTraveled;
	public float gameOverY = -6;
	public static Vector3 startPosition;

	//Player handling
	public float gravity = 20;
	public float walkSpeed = 8;
	public float runSpeed = 12;
	public float acceleration = 12;
	public float jumpHeight = 12;

	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;

	private PlayerPhysics playerPhysics;

	private bool canDoubleJump;

	 AudioSource dying;

	//private Animator animator;

	// Use this for initialization
	void Start () {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		startPosition = transform.localPosition;
		GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
		rigidbody.isKinematic = true;
		enabled = false;
		playerPhysics = GetComponent<PlayerPhysics> ();

		dying = GetComponent<AudioSource>();

		animation.wrapMode = WrapMode.Loop;
		animation ["Slide"].wrapMode = WrapMode.Once;
		animation["Jump"].wrapMode = WrapMode.Once;
		animation["Death"].wrapMode = WrapMode.Once;

		animation ["Slide"].layer = 1;
		animation ["Jump"].layer = 1;
		animation ["Death"].layer = 2;

		animation.Stop ();

	}
	
	// Update is called once per frame
	void Update () {

		//keep track of how far the player has moved
		distanceTraveled = transform.localPosition.x;
		GUIManager.SetDistance (distanceTraveled);

		if(transform.localPosition.y < gameOverY){

			//dying.Play();

			GameEventManager.TriggerGameOver();


		}
	
		if (playerPhysics.movementStopped)
		{
			targetSpeed = 0;
			currentSpeed = 0;
		}

		//animator.SetFloat ("Speed", currentSpeed); 

		//input
		float speed = (Input.GetButton("Run"))?runSpeed:walkSpeed;
		targetSpeed = Input.GetAxisRaw ("Horizontal") * speed;
		currentSpeed = IncrementTowards (currentSpeed, targetSpeed, acceleration);
		animation.Play ("Walk");
		animation["Walk"].speed = currentSpeed;
		animation.CrossFade("Walk");


		if (Mathf.Abs(Input.GetAxis("Horizontal")) <= 0.1 || !playerPhysics.grounded)
		{
			animation.Play("Idle");
			animation.CrossFade("Idle");
		}

		if (playerPhysics.grounded) 
		{
			canDoubleJump = true;
			amountToMove.y = 0;
			//Jump
			if(Input.GetButtonDown("Jump"))
			{
				amountToMove.y = jumpHeight;
				animation.CrossFade("Jump");

			}
		}

		if(canDoubleJump && !playerPhysics.grounded)
		{
			if(Input.GetButtonDown("Jump"))
			{
				amountToMove.y = jumpHeight;
				canDoubleJump = false;
				animation.CrossFade("Jump");
			}
		}
		
		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move (amountToMove * Time.deltaTime);

		//Slide
		if (Input.GetButtonDown ("Slide")) 
		{
			animation.CrossFade("Slide");

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

	private void GameStart () {
		distanceTraveled = 0f;
		GUIManager.SetDistance (distanceTraveled);
		transform.localPosition = startPosition;
		GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
		rigidbody.isKinematic = false;
		enabled = true;
	}
	
	private void GameOver () {
		GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
		rigidbody.isKinematic = true;
		enabled = false;

		//dying.Play();
		//dying.SetScheduledEndTime (3);
		//yield return new WaitForSeconds(3);
		//dying.Stop();
	}
}
