using UnityEngine;
using System.Collections;

public class deadPartsLogic : MonoBehaviour {

	public float solidifyTime = 10.0f;

	public Vector3 impactPoint;

	void OnEnable () {
		foreach (Rigidbody2D part in GetComponentsInChildren<Rigidbody2D> ()) {
			part.gravityScale = 1.0f;
			part.fixedAngle = false;
			float xforce = Random.Range (0.0f, 30.0f);
			part.AddForceAtPosition (new Vector2(xforce,Random.Range (40.0f, 180.0f)),impactPoint);
		}
		Invoke ("solidify", solidifyTime);
	}
	
	void solidify() {
		foreach (Rigidbody2D part in GetComponentsInChildren<Rigidbody2D> ()) {
			part.isKinematic = true;
		}
		foreach (PolygonCollider2D part in GetComponentsInChildren<PolygonCollider2D> ()) {
			part.tag = "ground";
		}
	}

}
