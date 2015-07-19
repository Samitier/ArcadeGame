using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsPlayer : MonoBehaviour {
	public float initY = 0.0f;
	public Text pointsText;

	private float maxY = 0.0f;
	private GameObject player;
	private int points = 0;

	// Use this for initialization
	void Start () {
		maxY = initY;
		player = GameObject.FindGameObjectWithTag ("Player");
		pointsText.text = points.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y > maxY) {
			maxY = player.transform.position.y;
			points = (int) ((maxY-initY)*1000.0f);
			pointsText.text = points.ToString();
		}
	}
}
