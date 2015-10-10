using UnityEngine;
using System.Collections;

public class onDestroyInstantiate : MonoBehaviour {
	public GameObject obj;
	public float yoffset;

	void OnDestroy() {
		Instantiate (obj, transform.position + new Vector3(0.0f,yoffset, 0.0f), transform.rotation);
	}
}
