using UnityEngine;
using System.Collections;

public class PointsPlayer : MonoBehaviour {
	public float initY = 0.0f;

	private float maxY = 0.0f;
	private GameObject player;
	private int points = 0;

	// Use this for initialization
	void Start () {
		maxY = initY;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y > maxY) {
			maxY = player.transform.position.y;
			points = (int) (maxY-initY)*1000;
			Debug.Log(points);
		}
	}
}
