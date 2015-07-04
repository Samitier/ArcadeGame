using UnityEngine;
using System.Collections;

public class lifeCount : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void playerDied() {
		playerLife plife = player.GetComponent<playerLife> ();
		if (plife.numLifes == 0)
			Debug.Log ("GAME OVER!!");
		else {
			plife.numLifes--;
			Debug.Log ("Lives remaining:" + plife.numLifes);
			Invoke ("respawn", plife.respawnTime);
		}
	}

	void respawn() {
			player.transform.position = new Vector3(0.0f,2.0f,0.0f);
			player.SetActive(true);
			player.SendMessage("respawn");
	}
}
