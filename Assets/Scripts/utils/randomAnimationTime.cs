using UnityEngine;
using System.Collections;

public class randomAnimationTime : MonoBehaviour {

	public float minTime = 2.5f;
	public float maxTime = 20.0f;

	private Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		Invoke ("playAnimation",Random.Range( minTime, maxTime));
	}
	
	// Update is called once per frame
	void playAnimation () {
		anim.SetTrigger ("smoke");
		Invoke ("playAnimation",Random.Range (minTime, maxTime));
	}
}
