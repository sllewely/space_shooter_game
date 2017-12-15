using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragmenter : MonoBehaviour {

	public GameObject fragmentParentPrefab;

	public int life = 3;
	public float pushForce;

	public Rigidbody2D myRigid;
	private bool isInitialized = false;

	void OnEnable() {
		isInitialized = true;
	}

	void FixedUpdate() {
		if (isInitialized) {
			Vector2 randomVector2Force = new Vector2 (Random.Range (-1f, 1f), Random.Range (-1f, 1f));

			myRigid.AddForce (randomVector2Force * pushForce, ForceMode2D.Impulse);

			isInitialized = false;
		}
	}

	void OnCollisionEnter2D()
	{
		life--;

		if (life <= 0) {
			Instantiate (fragmentParentPrefab, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
