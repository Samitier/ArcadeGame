﻿using UnityEngine;
using System.Collections;

public class playerLife : MonoBehaviour {
	public float killYVeloc = 1.0f;
	public int numLifes = 3;
	public float respawnTime=2.0f;
	public float timeInvincible =3.0f;

	private float time = 0.0f;
	private bool isInvincible = false;

	void Update() {
		if (isInvincible) {
			time += Time.deltaTime;
			SpriteRenderer rend = gameObject.GetComponent<SpriteRenderer>();
			if(time<=0.5f) rend.color = new Vector4(rend.color.r, rend.color.g, rend.color.b, 1.0f - (time / 0.5f));
			else {
				rend.color = new Vector4(rend.color.r, rend.color.g, rend.color.b, (time-0.5f) / 0.5f);
				if(time>=1.0f) time-=1.0f;
			}
		}
	}


	void OnCollisionEnter2D( Collision2D col) {
		if (col.collider.tag == "enemy" && !isInvincible) {
			if(col.gameObject.GetComponent<Rigidbody2D>().velocity.y<-killYVeloc) {
				die ();
			}
		}
	}

	void OnTriggerEnter2D( Collider2D col) {
		if (col.tag == "enemyBullet" && !isInvincible) {
			Destroy (col.gameObject);
			die ();
		}
	}

	void die() {
		SendMessage("explode");
		GameObject gameControl = GameObject.FindGameObjectWithTag ("MainCamera");
		gameControl.SendMessage ("playerDied");
		gameObject.SetActive (false);
	}
	
	void respawn() {
		isInvincible = true;
		Invoke ("toggleInvincibility", timeInvincible);
	}

	void toggleInvincibility() {
		isInvincible = !isInvincible;
	}
}
