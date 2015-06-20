using UnityEngine;
using System.Collections;

public class enemyBehavior : MonoBehaviour {

	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.

	
	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.

	private float direction=0;
	private bool isDead = false;
	//private Animator anim;					// Reference to the player's animator component.
	
	
	void Awake()
	{
		//anim = GetComponent<Animator>();
		InvokeRepeating ("changeMov", 0.0f, 1.0f);
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
		
			if (direction * GetComponent<Rigidbody2D> ().velocity.x < maxSpeed)
				GetComponent<Rigidbody2D> ().AddForce (Vector2.right * direction * moveForce);
		
			if (Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x) > maxSpeed)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (Mathf.Sign (GetComponent<Rigidbody2D> ().velocity.x) * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		
			if (direction > 0 && !facingRight)
				Flip ();
			else if (direction < 0 && facingRight)
				Flip ();
		}
	}
	
	
	void Flip ()
	{
		facingRight = !facingRight;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void die() {
		isDead = true;
		Rigidbody2D r = GetComponent<Rigidbody2D> ();
		r.gravityScale = 1.0f;
		r.fixedAngle = false;
	}

	void OnTriggerEnter2D( Collider2D col) {
		if (col.tag == "playerBullet") {
			Destroy (col.gameObject);
			die ();
		}
	}

	void OnCollisionEnter2D( Collision2D col) {
		if (col.collider.tag == "ground") {
			GetComponent<Rigidbody2D> ().isKinematic = true;
			gameObject.GetComponent<PolygonCollider2D>().tag = "ground";
			gameObject.layer = col.gameObject.layer;
		}
	}
}
