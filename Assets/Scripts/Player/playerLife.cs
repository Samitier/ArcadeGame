using UnityEngine;
using System.Collections;

public class playerLife : MonoBehaviour {
	public float killYVeloc = 1.0f;

	void OnCollisionEnter2D( Collision2D col) {
		if (col.collider.tag == "enemy") {
			if(col.gameObject.GetComponent<Rigidbody2D>().velocity.y<-killYVeloc) {
				SendMessage ("explode");
				Destroy (gameObject);
			}
		}
	}
}
