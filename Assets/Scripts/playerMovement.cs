﻿using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.
	
	
	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public float jumpForce = 1000f;			// Amount of force added when the player jumps.

	
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	//private Animator anim;					// Reference to the player's animator component.
	
	
	void Awake()
	{
		groundCheck = transform.Find("groundCheck");
		//anim = GetComponent<Animator>();
	}
	
	
	void Update()
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  
		
		if(Input.GetAxis ("Vertical")>0 && grounded)
			jump = true;
	}
	
	
	void FixedUpdate ()
	{
		float h = Input.GetAxis("Horizontal");

		//anim.SetFloat("Speed", Mathf.Abs(h));

		if(h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
			GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);
		
		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		
		if(h > 0 && !facingRight)
			Flip();
		else if(h < 0 && facingRight)
			Flip();
		
		if(jump)
		{
			//anim.SetTrigger("Jump");
			
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
	}
	
	
	void Flip ()
	{
		facingRight = !facingRight;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}