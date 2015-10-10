using UnityEngine;
using System.Collections;

public class onStartDestroy : MonoBehaviour {
	public float timeAlive;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, timeAlive);
	}

}
