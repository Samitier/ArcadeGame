using UnityEngine;
using System.Collections;

public class bulletDespawner : MonoBehaviour {

	void OnTriggerEnter2D( Collider2D col) {
		if (col.tag == "playerBullet")
			Destroy (col.gameObject);
	}
}
