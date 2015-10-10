using UnityEngine;
using System.Collections;

public class enemyDeath : MonoBehaviour {

	public float life= 5;
	public float solidifyTime = 10.0f;


	void die(Vector3 pos) {
		SendMessage ("explode");
		GetComponent<enemyMovement> ().isDead = true;
		bool facingRight = GetComponent<enemyMovement> ().facingRight; 
		Rigidbody2D r = GetComponent<Rigidbody2D> ();

		r.gravityScale = 1.0f;
		r.fixedAngle = false;

		float xforce = Random.Range (0.0f, 50.0f);
		if (!facingRight)
			xforce *= -1; 
		r.AddForceAtPosition (new Vector2(xforce,Random.Range (100.0f, 400.0f)),pos);
		gameObject.layer = LayerMask.NameToLayer ("Ground");
		Invoke ("solidify", solidifyTime);
	}

	void solidify() {
		GetComponent<Rigidbody2D> ().isKinematic = true;
		gameObject.GetComponent<PolygonCollider2D>().tag = "ground";
	}
	
	void OnTriggerEnter2D( Collider2D col) {
		if (col.tag == "playerBullet") {
			Destroy (col.gameObject);
			if(life>0) {
				life--;
				if(life <= 0) {
				    die (col.transform.position);
				}
			}
		}
	}
}
