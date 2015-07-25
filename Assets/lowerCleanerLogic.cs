using UnityEngine;
using System.Collections;

public class lowerCleanerLogic : MonoBehaviour {

	private GameObject player;
	
	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnTriggerEnter2D( Collider2D col) {
		if (col.tag == "enemy"||col.tag=="ground")
			Destroy (col.gameObject);
		else if (col.tag == "Player")
			player.SendMessage ("die");
	}
}
