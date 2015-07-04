using UnityEngine;
using System.Collections;

public class enemyShoot : MonoBehaviour {

	public GameObject bullet;
	public float bulletVelocity = 20.0f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("shoot", 0.0f, 3.0f);
	}
	
	void shoot () {
		if (!gameObject.GetComponent<enemyMovement> ().isDead) {
			GameObject bu = (GameObject)Instantiate (bullet, transform.position, transform.rotation);
			bu.GetComponent<Rigidbody2D> ().velocity = Vector3.down * bulletVelocity;
		}
	}
}
