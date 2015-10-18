using UnityEngine;
using System.Collections;

public class enemyDeath : MonoBehaviour {

	public float life= 5;


	void die(Vector3 pos) {
		SendMessage ("explode");
		GetComponent<enemyMovement> ().isDead = true;

		GetComponent<PolygonCollider2D> ().enabled = false;
		Transform deadParts = transform.parent.FindChild ("dead");
		deadParts.GetComponent<deadPartsLogic> ().impactPoint = pos;
		deadParts.position = transform.position;
		deadParts.gameObject.SetActive (true);
		gameObject.SetActive (false);

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
