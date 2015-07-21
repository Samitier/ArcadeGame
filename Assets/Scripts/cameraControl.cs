using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, player.transform.position.y+2.25f, transform.position.z);
	}
}
