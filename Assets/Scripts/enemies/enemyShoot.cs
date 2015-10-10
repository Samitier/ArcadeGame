using UnityEngine;
using System.Collections;

public class enemyShoot : MonoBehaviour {

	public GameObject bullet;
	public GameObject shootParticles;
	public float shootParticlesAnimTime;
	public float bulletVelocity = 20.0f;
	public float bulletYOffset;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("shoot", 0.0f, 4.0f);
	}

	void disableParticles() {
		GameObject bu = (GameObject)Instantiate (bullet, transform.position+new Vector3(0.0f,bulletYOffset, 0.0f), transform.rotation);
		bu.GetComponent<Rigidbody2D> ().velocity = Vector3.down * bulletVelocity;
		shootParticles.SetActive (false);
	}

	void shoot () {
		if (!gameObject.GetComponent<enemyMovement> ().isDead) {
			shootParticles.SetActive (true);
			Invoke ("disableParticles", shootParticlesAnimTime);
		}
	}
}
