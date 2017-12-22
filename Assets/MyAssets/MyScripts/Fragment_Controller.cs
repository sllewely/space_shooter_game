using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragment_Controller : MonoBehaviour {

	public int fragmentHealth;
	public Rigidbody2D myRigid;
	public float pushForce;

	private bool isInitialized = false;

	void OnEnable() {
		isInitialized = true;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (fragmentHealth <= 0) {
			Destroy (gameObject);
		}

		float distance = Vector3.Distance (transform.position, Camera.main.transform.position);
		if (distance > 50) {
			Destroy (transform.parent.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D objectThatHitMe) {
		Debug.Log ("hit by " + objectThatHitMe.gameObject.tag);
		if (objectThatHitMe.gameObject.tag == "LaserShot_Basic") {
			fragmentHealth--;
		}
	}

	void FixedUpdate() {
		if (isInitialized) {
			Vector2 randomVector2Force = new Vector2 (Random.Range (-1f, 1f), Random.Range (-1f, 1f));
			myRigid.AddForce (randomVector2Force * pushForce, ForceMode2D.Impulse);
			isInitialized = false;
		}
	}
}
