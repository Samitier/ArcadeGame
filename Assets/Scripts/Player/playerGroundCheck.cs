using UnityEngine;
using System.Collections;

public class playerGroundCheck : MonoBehaviour {

	void OnTriggerStay2D( Collider2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			GetComponentInParent<playerMovement> ().grounded = true;
		}
	}

	void OnTriggerExit2D( Collider2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			GetComponentInParent<playerMovement> ().grounded = false;
		}
	}
}
