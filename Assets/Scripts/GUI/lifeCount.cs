using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class lifeCount : MonoBehaviour {

	public  Text lifeText;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		lifeText.text = player.GetComponent<playerLife> ().numLifes.ToString();
	}
	
	// Update is called once per frame
	void playerDied() {
		playerLife plife = player.GetComponent<playerLife> ();
		if (plife.numLifes == 0)
			Debug.Log ("GAME OVER!!");
		else {
			plife.numLifes--;
			Invoke ("respawn", plife.respawnTime);
		}
		lifeText.text = plife.numLifes.ToString();
	}

	void respawn() {
		player.transform.position = new Vector3(transform.position.x,transform.position.y,player.transform.position.z);
			player.SetActive(true);
			player.SendMessage("respawn");
	}
}
