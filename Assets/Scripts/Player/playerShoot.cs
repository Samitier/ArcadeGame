using UnityEngine;
using System.Collections;

public class playerShoot : MonoBehaviour {

	public GameObject bullet;
	public float bulletVelocity = 20.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//should change on settings for shoot
		if (Input.GetButtonDown ("Jump")) {
			GameObject bu = (GameObject) Instantiate(bullet, transform.position, transform.rotation);
			bu.GetComponent<Rigidbody2D>().velocity = Vector3.up*bulletVelocity;
		}
	}
}
