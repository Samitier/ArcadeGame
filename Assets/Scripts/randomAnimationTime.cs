using UnityEngine;
using System.Collections;

public class randomAnimationTime : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		Invoke ("playAnimation",Random.Range( 5.0f, 5.0f));
	}
	
	// Update is called once per frame
	void playAnimation () {
		anim.Play ("smallSmoke_");
		Invoke ("playAnimation",Random.Range (5.0f, 5.0f));
	}
}
