using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot_Controller : MonoBehaviour {

	public Rigidbody2D laserRigid;
	public float laserSpeed;

	// Use this for initialization
	void Start () {
		DestroyObjectDelayed ();
		laserRigid.velocity = transform.up * laserSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D() {
		Destroy (gameObject);
	}

	void DestroyObjectDelayed() {
		Destroy (gameObject, 5);
	}
}
