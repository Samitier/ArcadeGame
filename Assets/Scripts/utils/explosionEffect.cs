using UnityEngine;
using System.Collections;

public class explosionEffect : MonoBehaviour {

	public Rigidbody2D particle;
	public float particleSpeed = 10.0f;
	public float lifespan = 5.0f;
	public int numParticles = 30;

	void explode() {
		for(int i=0; i< numParticles; ++i) {
			Rigidbody2D part = (Rigidbody2D) Instantiate(particle, transform.position, transform.rotation);
			part.velocity = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f) * particleSpeed;
			Destroy(part.gameObject, lifespan);
		}

	}
}
