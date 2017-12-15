using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowScript : MonoBehaviour {

	// Store a reference to the ship's game object
	// This will be used to  grab the ship's location later on in the script
	public GameObject theShip;

	// Store a speed we want the camera to follow the ship
	public float followSpeed;

	void FixedUpdate() {
		// Using the Vector2.Distance function, which is used to calculate the distance 
		// between game objects, we store/update the distance between the 
		// Cam_Controller game object's transform and the ship's transform position
		// on every fixed update frame.

		// We will use this value each frame to help update the position of the camera.
		float cameraToShipDistance = Vector2.Distance (transform.position, theShip.transform.position);

		// Lerp is linear interpolation
		 float followRate = followSpeed * cameraToShipDistance * Time.deltaTime;
		transform.position = Vector2.Lerp (transform.position, theShip.transform.position, followRate);

	}
}
