using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

	public Color gizmoColor;
	public float spawnRadius;
	public Transform shipTransform;

	void OnDrawGizmos() {
		Gizmos.color = gizmoColor;
		Gizmos.DrawSphere (shipTransform.position, spawnRadius);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
