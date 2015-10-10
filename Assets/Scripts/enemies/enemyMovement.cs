using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {

	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool isDead = false;
	public float minY = 0.2f;

	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.

	private float direction=0;

	//private Animator anim;					// Reference to the player's animator component.
	
	
	void Awake()
	{
		//anim = GetComponent<Animator>();
		InvokeRepeating ("changeMov", 0.0f, 1.0f);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -1.0f);
	}
	
	void changeMov(){
		direction = Random.Range (-1.0f, 1.0f);

	}

	void Update()
	{

	}
	
	
	void FixedUpdate ()
	{
		if (!isDead) {
			//anim.SetFloat("Speed", Mathf.Abs(h));
			if(transform.position.y<minY) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, 0.0f);
			}
			if (direction * GetComponent<Rigidbody2D> ().velocity.x < maxSpeed)
				GetComponent<Rigidbody2D> ().AddForce (Vector2.right * direction * moveForce);
		
			if (Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x) > maxSpeed)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (Mathf.Sign (GetComponent<Rigidbody2D> ().velocity.x) * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		
		}
	}

	
}
