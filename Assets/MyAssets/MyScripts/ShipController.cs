using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	public AudioSource soundPlayer;
	public AudioClip laserShotSound;

	[Range (0.0f, 1.0f)]
	public float laserShotVolume;

	public Transform laserLauncherTransformLeft;
	public Transform laserLauncherTransformRight;
	public GameObject laserShotPrefab;

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
//		if (Input.GetMouseButtonDown (0)) {
		if (Input.GetKeyDown(KeyCode.Space)) {
			ShootLaser ();
		}

		if (Input.GetKeyDown (KeyCode.D)) {
			
			PrintDebug ();
		}

		isEngineOn = Input.GetKey (KeyCode.UpArrow);

		horizontalInputValue = Input.GetAxis("Horizontal");
	}

	// use every time for physics interactions
	void FixedUpdate() {
		if (isEngineOn) {
			shipRigidBody.AddForce (transform.up * shipSpeed);
			flames.Emit (10);
		}

		// torque is for a rotating object
		shipRigidBody.AddTorque(turnSpeed * - horizontalInputValue);
	}

	public void ShootLaser() {
		soundPlayer.PlayOneShot (laserShotSound, laserShotVolume);
		Instantiate (laserShotPrefab, laserLauncherTransformLeft.position, laserLauncherTransformLeft.rotation);
		Instantiate (laserShotPrefab, laserLauncherTransformRight.position, laserLauncherTransformRight.rotation);
	}



	void PrintDebug() {
		Debug.Log (Input.GetAxis ("Horizontal").ToString ());
	}
}
