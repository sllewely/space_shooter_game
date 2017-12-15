using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	public Rigidbody2D shipRigidBody;
	public float shipSpeed;
	public float turnSpeed;
	public ParticleSystem flames;

	private float horizontalInputValue;
	bool isEngineOn = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	// fine to do inputs inside of update
	void Update () {
		if (Input.GetKeyDown (KeyCode.D)) {
			
			PrintDebug ();
		}

		isEngineOn = Input.GetKey (KeyCode.Space);

		horizontalInputValue = Input.GetAxis("Horizontal");
	}

	// use every time for physics interactions
	void FixedUpdate() {
		if (isEngineOn) {
			shipRigidBody.AddForce (transform.up * shipSpeed);
		}

		// torque is for a rotating object
		shipRigidBody.AddTorque(turnSpeed * - horizontalInputValue);
	}

	void PrintDebug() {
		Debug.Log (Input.GetAxis ("Horizontal").ToString ());
	}
}
