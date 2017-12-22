using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDeath : MonoBehaviour {

	public float lifeTimer;
	private float lifeRemaining;
	public float dangerDistance;


	// Use this for initialization
	void Start () {
		lifeRemaining = lifeTimer;
	}
	
	// Update is called once per frame
	void Update () {
		float distanceFromCamera = Vector3.Distance (transform.position, Camera.main.transform.position);
		lifeRemaining -= Time.deltaTime;
		if (distanceFromCamera > dangerDistance) {
			Debug.Log ("death by distance " + distanceFromCamera);
			Destroy (gameObject);
		}
		if (lifeRemaining <= 0) {
			Debug.Log ("death by time");
			Destroy (gameObject);
		}
	}
}
