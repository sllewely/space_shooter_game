﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	public Rigidbody2D shipRigidBody;
	public float shipSpeed;
	public float turnSpeed;

	private float horizontalInputValue;
	bool isEngineOn = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.D)) {
			
			PrintDebug ();
		}

		isEngineOn = Input.GetKey (KeyCode.Space);

		horizontalInputValue = Input.GetAxis("Horizontal");
	}

	void PrintDebug() {
		Debug.Log (Input.GetAxis ("Horizontal").ToString ());
	}
}
