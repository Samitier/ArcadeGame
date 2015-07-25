using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {
	
		public float yMargin = 1f;		// Distance in the y axis the player can move before the camera follows.
		public float ySmooth = 8f;		// How smoothly the camera catches up with it's target movement in the y axis.
		public float minY;		// The minimum y coordinates the camera can have.
		public float maxY;		// The maximum y coordinates the camera can have.
		
		private GameObject player;		// Reference to the player's transform.
		
		
		void Awake ()
		{
			// Setting up the reference.
			player = GameObject.FindGameObjectWithTag("Player");
		}
		
		
		bool CheckYMargin()
	{	
		return (transform.position.y-yMargin - player.transform.position.y) < 0.0f;
		}
		
		
		void FixedUpdate ()
		{
		 if(player.activeSelf) 
			if(!player.GetComponent<playerLife>().isInvincible)
				TrackPlayer();
		}
		
		
		void TrackPlayer ()
		{
			// By default the target x and y coordinates of the camera are it's current x and y coordinates.
			float targetY = transform.position.y;

			// If the player has moved beyond the y margin...
			if(CheckYMargin())
				// ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
			targetY = Mathf.Lerp(transform.position.y, player.transform.position.y+yMargin, ySmooth * Time.deltaTime);
			
			targetY = Mathf.Clamp(targetY, minY, maxY);
			
			// Set the camera's position to the target position with the same z component.
		    transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
		}

}
