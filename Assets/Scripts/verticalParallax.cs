using UnityEngine;
using System.Collections;

public class verticalParallax : MonoBehaviour {

	public GameObject[] layers;
	public float[] movRate;
	public GameObject stars;
	public float maxYpos = 19.1f;
	private float[] initPos;
	private float initPosCamera;
	private GameObject mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera =  GameObject.FindGameObjectWithTag("MainCamera");
		initPos = new float[layers.Length];
		initPosCamera = mainCamera.transform.position.y;
		for (int i=0; i<layers.Length; ++i) {
			initPos[i] = layers[i].transform.position.y;
		}
	}

	// Update is called once per frame
	void Update () {
		int i = 0;
		foreach (GameObject layer in layers) {
			layer.transform.position = new Vector3 (layer.transform.position.x, (mainCamera.transform.position.y-initPosCamera)*movRate[i]+initPos[i], layer.transform.position.z);
			++i;
		}
		SpriteRenderer rend = stars.GetComponent<SpriteRenderer> (); 
		rend.color = new Vector4(rend.color.r, rend.color.g, rend.color.b, Mathf.Max (0.0f, mainCamera.transform.position.y-(maxYpos/2.0f)) / maxYpos);
	}
}
