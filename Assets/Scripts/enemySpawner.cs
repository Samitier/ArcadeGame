using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {

	public GameObject enemy;
	public float spawnRate = 1.0f;
	public float spawnArea = 10.0f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawn", 0.0f, spawnRate);
	}
	
	void spawn() {
		Vector3 position = new Vector3(Random.Range (transform.position.x - (spawnArea / 2), transform.position.x + (spawnArea / 2)), transform.position.y, transform.position.z);
		Instantiate (enemy, position, transform.rotation);
	}
}
